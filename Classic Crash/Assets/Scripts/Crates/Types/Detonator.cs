using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonator : MonoBehaviour, IInteractable
{
    [HideInInspector]
    public List<Nitro> Nitros = new List<Nitro>();
    [HideInInspector]
    public bool HasDetonated;
    private Animator Activation;
    public AudioSource ActivatorSFX;
    public AudioSource ExplosionSFX;

    private void Awake()
    {
        Activation = gameObject.GetComponentInChildren<Animator>();
        Setup();

    }

    public void Setup()
    {
        Nitros = new List<Nitro>();
        HasDetonated = false;
        Activation.SetBool("Active", false);
        Nitro[] Crates = FindObjectsOfType(typeof(Nitro)) as Nitro[];
        foreach(Nitro Crate in Crates)
        {
            Nitros.Add(Crate);
        }

    }

    public void Interacting(int Side)
    {
        if (Side <= 2)
            Detonate();
        else if (Side == 7 || Side == 8)
            Detonate();
    }

    private void Detonate()
    {
        if (!HasDetonated)
        {
            ActivatorSFX.Play();
            ExplosionSFX.Play();
            Activation.SetBool("Active", true);
            gameObject.GetComponentInChildren<Renderer>().enabled = true;
            HasDetonated = true;            
            foreach (Nitro crate in Nitros)
            {
                if (crate.gameObject.activeSelf)
                    crate.Explode();
            }
        }       
    }
}
