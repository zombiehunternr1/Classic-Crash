using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour, ICrateBase
{
    public GameObject Wumpa;
    public GameObject BrokenEffect;
    public CrateType crateType;
    public int breakAfter = 5;
    public float DistanceRadius = 0.1f;
    public float BounceForce = 10;
    public int Amount = 1;
    public bool AutoAdd;
    public GameEventTransform CrateBroken;
    public GameEventInt AddWumpa;
    public AudioSource BreakSFX;
    public AudioSource BounceSFX;

    [HideInInspector]
    public bool IsBonus { get; set; }
    private bool IsBroken;
    private bool FirstBounce;
    private int currentBounces;
    private float CurrentTime;
    private float MaxTime = 5f;



    public void Break(int Side)
    {
        switch (crateType)
        {
            case CrateType.Unbreakable:
                if(Side == 1)
                {
                    BounceSFX.Play();
                    Bouncing();
                }
                break;
            case CrateType.BreakAfterX:
                if(Side == 1)
                {
                    BounceSFX.Play();
                    BreakAfterX();
                }
                else if(Side == 2)
                {
                    BounceSFX.Play();
                    BreakAfterX();
                    Bouncing();
                }
                else if(Side == 7)
                {
                    BreakSFX.Play();
                    Bouncing();
                    DisableCrate();
                }
                else if(Side == 8)
                {
                    BreakSFX.Play();
                    CrateBroken.RaiseTransform(transform);
                    AddWumpa.RaiseInt(5);
                    gameObject.SetActive(false);
                }
                else if(Side == 9)
                {
                    BreakSFX.Play();
                    AutoAdd = true;
                    DisableCrate();
                }
                break;
            case CrateType.BreakInstant:
                if(Side == 1)
                {
                    BounceSFX.Play();
                    Bouncing();
                }                   
                else if(Side == 7 || Side == 8)
                {
                    BreakSFX.Play();
                    AutoAdd = true;
                    DisableCrate();
                }
                else if(Side == 9)
                {
                    BreakSFX.Play();
                    CrateBroken.RaiseTransform(transform);
                    gameObject.SetActive(false);
                }
                break;
        }
    }

    public void DisableCrate()
    {
        if (!IsBroken)
        {
            Instantiate(BrokenEffect, transform.position, transform.rotation);
            Invoke("DelayInactive", 1f);
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Renderer>().enabled = false;
            BreakSFX.Play();
            IsBroken = true;
            CrateBroken.RaiseTransform(transform);
            if (AutoAdd && crateType == CrateType.BreakInstant)
            {
                AddWumpa.RaiseInt(Amount);
            }
            else if(crateType == CrateType.BreakInstant)
            {
                Instantiate(Wumpa, transform.position, transform.rotation);
            }            
        }
    }
    public void ResetCrate()
    {
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<Renderer>().enabled = true;
        IsBroken = false;
    }

    private void DelayInactive()
    {
        gameObject.SetActive(false);
    }

    public void BreakAfterX()
    {
        if (!FirstBounce)
        {
            AddWumpa.RaiseInt(Amount);
            FirstBounce = true;
            currentBounces++;
            Bouncing();
            StartCoroutine(ResetCounter());
        }
        else if (CurrentTime < MaxTime)
        {
            AddWumpa.RaiseInt(Amount);
            currentBounces++;
            CurrentTime = 0;
            if (currentBounces >= breakAfter)
            {
                Bouncing();
                BreakSFX.Play();
                DisableCrate();
                StopCoroutine(ResetCounter());
            }
            else
            {
                Bouncing();
            }
        }
        else
        {
            AddWumpa.RaiseInt(Amount);
            StopCoroutine(ResetCounter());
            CurrentTime = 0;
            BreakSFX.Play();
            Bouncing();
            DisableCrate();
        }
    }

    private void Bouncing()
    {
        RaycastHit MyRayHit;
        if (Physics.Raycast(transform.position, Vector3.up, out MyRayHit))
        {
            if (MyRayHit.collider != null)
            {
                InputManager Player = MyRayHit.collider.GetComponent<InputManager>();
                if (Player != null)
                {
                    BounceObject(Player.GetComponent<Rigidbody>(), BounceForce);
                }
            }
        }
        else if(Physics.Raycast(transform.position, -Vector3.up, out MyRayHit))
        {
            if (MyRayHit.collider != null)
            {
                InputManager Player = MyRayHit.collider.GetComponent<InputManager>();
                if (Player != null)
                {
                    BounceObject(Player.GetComponent<Rigidbody>(), -BounceForce);
                }
            }
        }
    }

    public void BounceObject(Rigidbody RB, float BounceForce)
    {
        RB.AddForce(new Vector3(0, BounceForce, 0), ForceMode.Impulse);
    }

    IEnumerator ResetCounter()
    {
        while (FirstBounce)
        {
            CurrentTime += Time.deltaTime;
            yield return CurrentTime;
        }
        yield return null;
    }

    public enum CrateType { Unbreakable, BreakInstant, BreakAfterX }
}
