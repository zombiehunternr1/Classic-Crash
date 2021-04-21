using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour, ICrateBase
{
    public CrateType crateType;
    public int breakAfter = 5;
    public float DistanceRadius = 0.1f;
    public float BounceForce = 7;
    
    private int currentBounces;
    private BoxCollider Hitbox;

    private void Awake()
    {
        Hitbox = GetComponent<BoxCollider>();
    }

    public void Break(int Side)
    {
        switch (crateType)
        {
            case CrateType.Unbreakable:
                if(Side == 1)
                    Bouncing();
                break;
            case CrateType.BreakAfterX:
                if(Side <= 2)
                    BreakAfterX();
                    Bouncing();
                break;
            case CrateType.BreakInstant:
                if(Side == 1)
                    Bouncing();
                else if(Side >=7)
                DisableCrate();
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IInteractable Crate = other.gameObject.GetComponent<IInteractable>();
        if(other != null)
        {

        }
    }

    public void DisableCrate()
    {
        gameObject.SetActive(false);
    }

    public void BreakAfterX()
    {
        currentBounces++;
        if (currentBounces >= breakAfter)
            DisableCrate();
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
    }
    public void BounceObject(Rigidbody RB, float BounceForce)
    {
        RB.AddForce(new Vector3(0, BounceForce, 0), ForceMode.VelocityChange);
    }
    public enum CrateType { Unbreakable, BreakInstant, BreakAfterX }
}
