using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Default : MonoBehaviour, ICrateBase, ISpawnable
{
    public GameObject Item;
    public GameObject BrokenEffect;
    public GameObject SpawnedItems;
    public bool AutoAdd;
    public bool HasGravity;
    public GameEventTransform CrateBroken;
    public GameEventInt AddWumpa;

    [HideInInspector]
    public bool IsBonus { get; set; }
    private bool IsBroken;
    private int Amount = 1;
    private Rigidbody RB;
    private bool CanBounce = true;
    private AudioSource BreakSFX;

    public void Break(int side)
    {
        switch (side)
        {
            case 1:
                SpawnItem();
                break;
            case 2:
                SpawnItem();
                break;
            case 7:
                SpawnItem();
                break;
            case 8:
                AutoAdd = true;
                SpawnItem();
                break;
            case 9:
                DisableCrate();
                break;
        }
    }

    private void Awake()
    {
        BreakSFX = GetComponent<AudioSource>();
        Physics.IgnoreLayerCollision(6, 7);
        RB = GetComponent<Rigidbody>();
        if (!HasGravity)
        {
            RB.constraints = RigidbodyConstraints.FreezeAll;
            RB.useGravity = false;
        }
        else
        {
            RB.useGravity = true;
            RB.mass = 0.1f;
        }
    }

    private void FixedUpdate()
    {
        if(RB.velocity.y > 3 && CanBounce)
        {
            CanBounce = false;
            RB.AddForce(transform.up * 0.1f, ForceMode.Impulse);
        }
        if(RB.velocity.y == 0)
        {
            CanBounce = true;
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
        }
    }
    public void ResetCrate()
    {
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<Renderer>().enabled = true;
        IsBroken = false;
    }

    public void SpawnItem()
    {
        if (AutoAdd)
        {
            AddWumpa.RaiseInt(Amount);
        }
        else
        {
            GameObject ItemSpawned = Instantiate(Item, transform.position, Quaternion.identity);
            ItemSpawned.transform.SetParent(SpawnedItems.transform);
        }
        DisableCrate();
    }
    private void DelayInactive()
    {
        gameObject.SetActive(false);
    }
}
