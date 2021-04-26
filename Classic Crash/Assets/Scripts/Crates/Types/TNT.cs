using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour, ICrateBase
{
    public ParticleSystem Explosion;
    public GameEvent CrateBroken;

    [HideInInspector]
    public bool IsGhost = false;
    [HideInInspector]
    public Animator AnimTNT;
    private List<Renderer> SubCrates = new List<Renderer>();

    private void Awake()
    {
        foreach(Renderer Subscrate in gameObject.GetComponentsInChildren<Renderer>())
        {
            SubCrates.Add(Subscrate);
        }
        AnimTNT = GetComponent<Animator>();
    }

    private void Start()
    {
        Setup();
    }

    public void Break(int Side)
    {
        switch (Side)
        {
            case 1:
                Countdown();
                break;
            case 2:
                Countdown();
                break;
            case 7:
                Explode();
                break;
            case 10:
                Explode();
                break;
        }
    }

    private void Setup()
    {
        if (IsGhost)
        {
            AnimTNT.SetBool("Active", false);
        }
        else
        {
            AnimTNT.SetTrigger("SetInactive");
            AnimTNT.SetBool("Active", false);
        }
    }

    public void CrateReset()
    {
        if (AnimTNT.GetCurrentAnimatorStateInfo(0).IsName("Ghost"))
        {
            if (IsGhost)
            {
                return;
            }
            else
            {
                AnimTNT.Play("Inactive");
                AnimTNT.SetBool("Active", false);
            }
            return;
        }
        else
        {
            if (gameObject.activeSelf)
            {
                if (IsGhost)
                {
                    if (AnimTNT.GetCurrentAnimatorStateInfo(0).IsName("Inactive"))
                    {
                        AnimTNT.SetTrigger("SetInactive");
                    }
                    else if (AnimTNT.GetCurrentAnimatorStateInfo(0).IsName("Active"))
                    {
                        AnimTNT.SetTrigger("SetInactive");
                    }

                }
                if (AnimTNT.GetCurrentAnimatorStateInfo(0).IsName("Active"))
                {
                    AnimTNT.SetBool("Active", false);
                }
                return;
            }
            else
            {
                AnimTNT.SetTrigger("SetInactive");
                AnimTNT.SetBool("Active", false);
            }
        }
    }

    public void Explode()
    {
        DisableEmission();
        DisableCrate();
        Instantiate(Explosion, transform.position, Quaternion.identity);
    }

    public void DisableCrate()
    {
        CrateBroken.Raise();
        gameObject.SetActive(false);
    }

    public void EnableEmission()
    {
        for(int i = 0; i < SubCrates.Count; i++)
        {
            SubCrates[i].material.EnableKeyword("_EMISSION");
        }
    }

    public void DisableEmission()
    {
        for (int i = 0; i < SubCrates.Count; i++)
        {
            SubCrates[i].material.DisableKeyword("_EMISSION");
        }
    }

    public void Countdown()
    {
        AnimTNT.SetBool("Active", true);
    }
}
