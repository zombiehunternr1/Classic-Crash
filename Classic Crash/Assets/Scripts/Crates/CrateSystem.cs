using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrateSystem : MonoBehaviour
{
    public GameEventTransform SpawnGem;
    [HideInInspector]
    public List<GameObject> CurrentlyBroken = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> BreakableCrates = new List<GameObject>();

    private List<GameObject> InteractCrates = new List<GameObject>();
    private List<GameObject> TotalCrates = new List<GameObject>();

    private int CurrentlyBrokenAmount;

    private void Awake()
    {
        GetAllCrateTypes();
        DisplayCrateCount();
    }

    private void GetAllCrateTypes()
    {
        GameObject[] AllCrates = FindObjectsOfType<GameObject>();

        foreach (GameObject Crate in AllCrates)
        {
            ICrateBase ICrate = Crate.GetComponent<ICrateBase>();
            if (ICrate != null)
            {
                if (Crate.GetComponent<Checkpoint>())
                {
                    var Checkpoint = Crate.GetComponent<Checkpoint>();
                    if (Checkpoint.crateType == Checkpoint.CrateType.Breakable)
                    {
                        BreakableCrates.Add(Crate);
                    }
                }
                else if (Crate.GetComponent<Bounce>())
                {
                    var Bounce = Crate.GetComponent<Bounce>();
                    if(Bounce.crateType == Bounce.CrateType.BreakAfterX || Bounce.crateType == Bounce.CrateType.BreakInstant)
                    {
                        BreakableCrates.Add(Crate);
                    }
                }

                else
                {
                    BreakableCrates.Add(Crate);
                }
            }
            IInteractable IInteract = Crate.GetComponent<IInteractable>();
            if(IInteract != null)
            {
                if (Crate.GetComponent<Activator>())
                {
                    InteractCrates.Add(Crate);
                }
                else if (Crate.GetComponent<Detonator>())
                {
                    InteractCrates.Add(Crate);
                }
            }
            if (Crate.GetComponent<TotalCrates>())
            {
                TotalCrates.Add(Crate);
            }
        }
    }

    private void DisplayCrateCount()
    {
        for(int i = 0; i < TotalCrates.Count; i++)
        {
            TotalCrates[i].GetComponent<TotalCrates>().BoxCrateUI.text = CurrentlyBrokenAmount + " / " + BreakableCrates.Count;
        }
    }

    public void ResetCrates()
    {
        AllBreakablesReset();
        AllInteractablesReset();
    }

    private void AllBreakablesReset()
    {
        foreach (GameObject Crate in BreakableCrates)
        {
            if (!CurrentlyBroken.Contains(Crate))
            {
                if (!Crate.activeSelf)
                {
                    CurrentlyBrokenAmount--;
                    Crate.SetActive(true);
                    if (Crate.GetComponent<Default>())
                    {
                        Crate.GetComponent<Default>().ResetCrate();
                        
                    }
                    if (Crate.GetComponent<AkuAkuCrate>())
                    {
                        Crate.GetComponent<AkuAkuCrate>().ResetCrate();
                    }
                    if (Crate.GetComponent<Bounce>())
                    {
                        Crate.GetComponent<Bounce>().ResetCrate();
                    }
                    if (Crate.GetComponent<LifeCrate>())
                    {
                        Crate.GetComponent<LifeCrate>().ResetCrate();
                    }
                    if (Crate.GetComponent<Questionmark>())
                    {
                        Crate.GetComponent<Questionmark>().ResetCrate();
                    }
                    if (Crate.GetComponent<Nitro>())
                    {
                        Crate.GetComponent<Nitro>().IsBroken = false;
                    }
                    if (Crate.GetComponent<TNT>())
                    {
                        Crate.GetComponent<TNT>().CrateReset();
                    }
                }
            }
        }
    }

    private void AllInteractablesReset()
    {
        foreach (GameObject Interact in InteractCrates)
        {
            if (InteractCrates.Contains(Interact))
            {
                if (Interact.GetComponent<Activator>())
                {
                    Activator ActivatorCrate = Interact.GetComponent<Activator>();
                    foreach (GameObject Crate in BreakableCrates)
                    {
                        if (ActivatorCrate.Crates.Contains(Crate))
                        {
                            if (!Crate.activeInHierarchy)
                            {
                                ActivatorCrate.Crates.Remove(Crate);
                            }
                        }
                    }
                    Interact.GetComponent<Activator>().Setup();
                }
                if (Interact.GetComponent<Detonator>())
                {
                    Detonator DetonatorCrate = Interact.GetComponent<Detonator>();
                    foreach (GameObject Crate in BreakableCrates)
                    {
                        if (DetonatorCrate.Nitros.Contains(Crate.GetComponent<Nitro>()))
                        {
                            DetonatorCrate.Setup();
                            break;
                        }
                    }
                }
            }
        }
    }

    public void UpdateCurrentCrateCount()
    {
        CurrentlyBrokenAmount++;
        DisplayCrateCount();
    }

    public void SaveCheckpointCount(int CurrentlyBroken)
    {
        CurrentlyBrokenAmount = CurrentlyBroken;
    }

    public void CheckTotalCount(Transform SpawnPosition)
    {
        if(CurrentlyBrokenAmount == BreakableCrates.Count)
        {
            SpawnGem.RaiseTransform(SpawnPosition);
        }
    }
}
