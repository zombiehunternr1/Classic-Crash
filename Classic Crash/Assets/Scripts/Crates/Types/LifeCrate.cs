using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCrate : MonoBehaviour, ICrateBase
{
    public GameObject Life;
    public bool AutoAdd;
    public GameEvent CrateBroken;
    [HideInInspector]
    public bool IsBroken;

    public void Break(int Side)
    {
        if(Side <= 2)
            SpawnLife();
        else if(Side == 7)
            SpawnLife();
        else if(Side == 8)
        {
            AutoAdd = true;
            SpawnLife();
        }
        else if(Side >= 9)
        {
            DisableCrate();   
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

    private void SpawnLife()
    {
        if (AutoAdd)
        {
            Debug.Log("auto add");
        }
        else
        {
            Instantiate(Life, transform.position, Quaternion.identity);
        }
        DisableCrate();
    }
}
