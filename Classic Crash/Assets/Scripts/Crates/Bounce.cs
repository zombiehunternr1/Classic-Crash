using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour, ICrateBase
{
    public CrateType crateType;
    public int breakAfter = 5;
    public float DistanceRadius = 0.1f;
    public float BounceForce = 10;

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
                    BounceUp();
                break;
            case CrateType.BreakAfterX:
                if(Side == 1)
                    BreakAfterX();
                else if(Side == 2)
                {
                    BreakAfterX();
                    BounceDown();
                }
                else if(Side >= 7)
                    DisableCrate();
                break;
            case CrateType.BreakInstant:
                if(Side == 1)
                    BounceUp();
                else if(Side >=7)
                DisableCrate();
                break;
        }
    }

    public void DisableCrate()
    {
        gameObject.SetActive(false);
    }

    public void BreakAfterX()
    {
        if (!FirstBounce)
        {
            FirstBounce = true;
            currentBounces++;
            BounceUp();
            StartCoroutine(ResetCounter());
        }
        else if (CurrentTime < MaxTime)
        {
            currentBounces++;
            CurrentTime = 0;
            if (currentBounces >= breakAfter)
            {
                BounceUp();
                DisableCrate();
                StopCoroutine(ResetCounter());
            }
            else
            {
                BounceUp();
            }
        }
        else
        {
            StopCoroutine(ResetCounter());
            CurrentTime = 0;
            BounceUp();
            DisableCrate();
        }
    }

    private void BounceUp()
    {
        RaycastHit MyRayHit;
        if (Physics.Raycast(transform.position, Vector3.up, out MyRayHit))
        {
            if (MyRayHit.collider != null)
            {
                InputManager Player = MyRayHit.collider.GetComponent<InputManager>();
                if (Player != null)
                {
                    Player.Jumping();
                }
            }
        }
    }

    private void BounceDown()
    {
        RaycastHit MyRayHit;
        if (Physics.Raycast(transform.position, -Vector3.up, out MyRayHit))
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
