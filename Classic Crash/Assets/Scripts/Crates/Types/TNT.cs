using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour, ICrateBase
{
    [HideInInspector]
    public bool IsGhost = false;
    public ParticleSystem Explosion;
    private List<Renderer> SubCrates = new List<Renderer>();
    [HideInInspector]
    public Animator AnimTNT;

    private void Awake()
    {
        foreach(Renderer TNT in gameObject.GetComponentsInChildren<Renderer>())
        {
            SubCrates.Add(TNT);
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
        if (AnimTNT.GetCurrentAnimatorStateInfo(0).IsName("SetInactive"))
        {
            if (IsGhost)
            {
                Debug.Log("Hallo");
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
        DisableCrate();
        Instantiate(Explosion, transform.position, Quaternion.identity);
    }

    public void DisableCrate()
    {
        gameObject.SetActive(false);
    }

    public void Countdown()
    {
        AnimTNT.SetBool("Active", true);
    }
}
