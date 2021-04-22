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

    private void Awake()
    {
        GetAllBreakableCrates();   
    }

    private void GetAllBreakableCrates()
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
        foreach(GameObject Crate in BreakableCrates)
        {
            if (!CurrentlyBroken.Contains(Crate))
            {
                Crate.SetActive(true);
            }
        }
    }
}
