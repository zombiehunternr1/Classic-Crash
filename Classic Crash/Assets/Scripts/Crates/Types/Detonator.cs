using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonator : MonoBehaviour, IInteractable
{
    private Animation AnimDetonate;
    [HideInInspector]
    public bool HasDetonated;

    private void Awake()
    {
        AnimDetonate = gameObject.GetComponentInChildren<Animation>();
    }

    public void Interacting(int Side)
    {
        if (Side <= 2)
            Detonate();
        else if (Side == 7)
            Detonate();
    }

    private void Detonate()
    {
        if (!HasDetonated)
        {
            HasDetonated = true;
            gameObject.GetComponent<Renderer>().enabled = false;
            AnimDetonate.Play();
            Nitro[] Crates = FindObjectsOfType(typeof(Nitro)) as Nitro[];
            foreach (Nitro crate in Crates)
            {
                if (crate.enabled)
                    crate.Explode();
            }
        }       
    }
}
