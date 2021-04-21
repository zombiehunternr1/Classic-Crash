using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour, ICrateBase
{
    public CrateType crateType;
    public int breakAfter = 5;
    public float DistanceRadius = 0.1f;
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
        foreach(Collider hit in hitColliders)
        {
            InputManager Player = Hitbox.gameObject.GetComponent<InputManager>();
            if (Player != null)
            {
                Player.Jump();
                Debug.Log("Bounce player");
            }
            ICrateBase Crate = (ICrateBase)Hitbox.gameObject.GetComponent(typeof(ICrateBase));
            if(Crate != null && gameObject != Hitbox.gameObject)
            {
                Debug.Log("Bounce crate");
            }
        }
    }
    public enum CrateType { Unbreakable, BreakInstant, BreakAfterX }
}
