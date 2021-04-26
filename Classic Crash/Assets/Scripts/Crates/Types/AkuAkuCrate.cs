using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkuAkuCrate : MonoBehaviour, ICrateBase
{
    public GameObject AkuAku;
    public bool AutoAdd;
    public GameEvent CrateBroken;

    public void Break(int Side)
    {
        if (Side <= 2)
            SpawnAkuAku();
        else if (Side == 7)
            SpawnAkuAku();
        else if (Side == 8)
        {
            AutoAdd = true;
            SpawnAkuAku();
        }
        else if (Side >= 9)
        {
            DisableCrate();
        }
    }
    public void DisableCrate()
    {
        CrateBroken.Raise();
        gameObject.SetActive(false);
    }

    private void SpawnAkuAku()
    {
        if (AutoAdd)
        {
            Debug.Log("auto add");
        }
        else
        {
            Instantiate(AkuAku, transform.position, Quaternion.identity);
        }
        DisableCrate();
    }
}
