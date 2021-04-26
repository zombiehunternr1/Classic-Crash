using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSystem : MonoBehaviour
{
    [HideInInspector]
    public List<GameObject> CurrentlyBroken = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> BreakableCrates = new List<GameObject>();

    private List<GameObject> InteractCrates = new List<GameObject>();

    public int CurrentlyBrokenAmount;

    private void Awake()
    {
        GetAllCrateTypes();
        Debug.Log(BreakableCrates.Count);
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
        }
    }

    public void ResetCrates()
    {
        foreach (GameObject Crate in BreakableCrates)
        {
            if (!CurrentlyBroken.Contains(Crate))
            {
                if (!Crate.activeSelf)
                {
                    CurrentlyBrokenAmount--;
                    Crate.SetActive(true);
                    if (Crate.GetComponent<TNT>())
                    {
                        Crate.GetComponent<TNT>().CrateReset();
                    }
                }               
            }
        }
        foreach (GameObject Interact in InteractCrates)
        {
            if (InteractCrates.Contains(Interact))
            {
                if (Interact.GetComponent<Activator>())
                {
                    Activator ActivatorCrate = Interact.GetComponent<Activator>();
                    foreach(GameObject Crate in BreakableCrates)
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
                    foreach(GameObject Crate in BreakableCrates)
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
    }

    public void SaveCheckpointCount(int CurrentlyBroken)
    {
        CurrentlyBrokenAmount = CurrentlyBroken;
    }

    public void CheckTotalCount(Transform SpawnPosition)
    {
        if(CurrentlyBrokenAmount == BreakableCrates.Count)
        {
            Debug.Log(SpawnPosition.position);
        }
    }
}
