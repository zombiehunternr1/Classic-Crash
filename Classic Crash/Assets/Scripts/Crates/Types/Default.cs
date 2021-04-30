using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Default : MonoBehaviour, ICrateBase, ISpawnable
{
    public GameObject Item;
    public bool AutoAdd;
    public GameEvent CrateBroken;
    public GameEventInt AddWumpa;

    [HideInInspector]
    public bool IsBroken;

    private int Amount = 1;

    public void Break(int side)
    {
        switch (side)
        {
            case 1:
                SpawnItem();
                break;
            case 2:
                SpawnItem();
                break;
            case 7:
                SpawnItem();
                break;
            case 8:
                AutoAdd = true;
                SpawnItem();
                break;
            case 9:
                DisableCrate();
                break;
        }
    }

    public void DisableCrate()
    {
        if (!IsBroken)
        {
            IsBroken = true;
            CrateBroken.Raise();
            gameObject.SetActive(false);
        }
    }

    public void SpawnItem()
    {
        if (AutoAdd)
        {
            AddWumpa.RaiseInt(Amount);
        }
        else
        {
            Instantiate(Item, transform.position, Quaternion.identity);
        }
        DisableCrate();
    }
}
