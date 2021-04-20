using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonator : MonoBehaviour, IInteractable
{
    public void Interacting(int Side)
    {
        if(Side <= 2)
        {
            Detonate();
        }
        else if(Side == 7)
        {
            Detonate();
        }
    }

    private void Detonate()
    {
        Nitro[] Crates = FindObjectsOfType(typeof(Nitro)) as Nitro[];

        foreach(Nitro crate in Crates)
        {
            crate.Explode();
        }
        gameObject.GetComponent<Renderer>().enabled = false;
    }
}
