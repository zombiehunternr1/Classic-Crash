using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour, ICrateBase
{
    public GameObject Wumpa;
    public CrateType crateType;
    public int breakAfter = 5;
    public float DistanceRadius = 0.1f;
    public float BounceForce = 10;
    public int Amount = 1;
    public bool AutoAdd;
    public GameEvent CrateBroken;
    public GameEventInt AddWumpa;
    [HideInInspector]
    public bool IsBroken;

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
                    GameManager.Instance.SFXCrateBounce();
                    Bouncing();
                }
                break;
            case CrateType.BreakAfterX:
                if(Side == 1)
                {
                    GameManager.Instance.SFXCrateBounce();
                    BreakAfterX();
                }
                else if(Side == 2)
                {
                    GameManager.Instance.SFXCrateBounce();
                    BreakAfterX();
                    Bouncing();
                }
                else if(Side == 7)
                {
                    GameManager.Instance.SFXCrateBreak();
                    Bouncing();
                    DisableCrate();
                }
                else if(Side == 8)
                {
                    GameManager.Instance.SFXCrateBreak();
                    CrateBroken.Raise();
                    AddWumpa.RaiseInt(5);
                    gameObject.SetActive(false);
                }
                else if(Side == 9)
                {
                    GameManager.Instance.SFXCrateBreak();
                    AutoAdd = true;
                    DisableCrate();
                }
                break;
            case CrateType.BreakInstant:
                if(Side == 1)
                {
                    GameManager.Instance.SFXCrateBounce();
                    Bouncing();
                }                   
                else if(Side == 7 || Side == 8)
                {
                    GameManager.Instance.SFXCrateBreak();
                    AutoAdd = true;
                    DisableCrate();
                }
                else if(Side == 9)
                {
                    GameManager.Instance.SFXCrateBreak();
                    CrateBroken.Raise();
                    gameObject.SetActive(false);
                }
                break;
        }
    }

    public void DisableCrate()
    {
        if (!IsBroken)
        {
            IsBroken = true;
            CrateBroken.Raise();
            if (AutoAdd && crateType == CrateType.BreakInstant)
            {
                AddWumpa.RaiseInt(Amount);
            }
            else if(crateType == CrateType.BreakInstant)
            {
                Instantiate(Wumpa, transform.position, transform.rotation);
            }
            gameObject.SetActive(false);
        }
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
                GameManager.Instance.SFXCrateBreak();
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
            GameManager.Instance.SFXCrateBreak();
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
