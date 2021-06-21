using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusLevel : MonoBehaviour
{
    public List<GameObject> BreakableCrates = new List<GameObject>();
    public List<GameObject> InteractCrates = new List<GameObject>();
    public List<GameObject> CurrentlyBroken = new List<GameObject>();

    private void OnEnable()
    {
        GameObject[] BonusCrates = FindObjectsOfType<GameObject>();

        foreach(GameObject Crate in BonusCrates)
        {
            ICrateBase ICrate = Crate.GetComponent<ICrateBase>();
           if(ICrate != null)
            {
                if (Crate.GetComponent<Bounce>())
                {
                    var Bounce = Crate.GetComponent<Bounce>();
                    if (Bounce.crateType == Bounce.CrateType.BreakAfterX || Bounce.crateType == Bounce.CrateType.BreakInstant)
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
            if (IInteract != null)
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
                    Crate.SetActive(true);
                    if (Crate.GetComponent<Default>())
                    {
                        Crate.GetComponent<Default>().ResetCrate();
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
                        Crate.GetComponent<TNT>().ResetCrate();
                    }
                }
            }
        }
    }
}
