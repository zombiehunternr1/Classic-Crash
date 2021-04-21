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
        Collider[] hitColliders = Physics.OverlapSphere(Hitbox.bounds.center, DistanceRadius);
        foreach(Collider Hit in hitColliders)
        {
            InputManager Player = Hit.gameObject.GetComponent<InputManager>();          
            if (Player != null)
            {
                Rigidbody RB = Player.GetComponent<Rigidbody>();
                BounceObject(RB);
            }
            ICrateBase Crate = (ICrateBase)Hit.gameObject.GetComponent(typeof(ICrateBase));
            if(Crate != null && Hit.gameObject != gameObject)
            {
                Rigidbody RB = Player.GetComponent<Rigidbody>();
                BounceObject(RB);
            }
        }
    }
    public enum CrateType { Unbreakable, BreakInstant, BreakAfterX }

    private void BounceObject(Rigidbody RB)
    {
        RB.AddForce(new Vector3(0, BounceForce, 0), ForceMode.Impulse);
    }
}
