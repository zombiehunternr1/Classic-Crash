using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questionmark : MonoBehaviour, ICrateBase, ISpawnable
{
    public GameObject Item;
    public int amount = 1;

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
        for (int i = 0; i < amount; i++)
        {
            if (i > 0)
            {
                var x = Random.Range(-0.5f, 0.5f);
                var z = Random.Range(-0.5f, 0.5f);
                Instantiate(Item, new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z), Quaternion.identity);
            }
            else
            {
                Instantiate(Item, transform.position, Quaternion.identity);
            }
        }
        DisableCrate();
    }
}
