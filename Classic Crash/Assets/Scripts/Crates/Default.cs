using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Default : MonoBehaviour, ICrateBase, ISpawnable
{
    public GameObject Item;
    public bool AutoAdd;

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
            case 10:
                DisableCrate();
                break;
        }
    }

    public void DisableCrate()
    {
        gameObject.SetActive(false);
    }

    public void SpawnItem()
    {
        if (AutoAdd)
        {
            Debug.Log("Auto add");
        }
        else
        {
            Instantiate(Item, transform.position, Quaternion.identity);
        }
        DisableCrate();
    }
}
