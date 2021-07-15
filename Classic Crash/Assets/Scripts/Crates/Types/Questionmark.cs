using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questionmark : MonoBehaviour, ICrateBase, ISpawnable
{
    public GameObject Wumpa;
    public GameObject BrokenEffect;
    public GameObject SpawnedItems;
    public GameObject Life;
    public GameEventTransform LevelCrateBroken;
    public GameEventTransform BonusCrateBroken;
    public GameEventInt AddWumpa;
    public GameEvent AddLife;
    public bool IsWumpa;
    public bool AutoAdd;
    public bool HasGravity;
    public int Amount = 1;

    [HideInInspector]
    public bool IsBonus { get; set; }
    private bool IsBroken;
    private bool WasLife = true;
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
        RB = GetComponent<Rigidbody>();
        if (!HasGravity)
        {
            RB.constraints = RigidbodyConstraints.FreezeAll;
            RB.useGravity = false;
        }
        else
        {          
            RB.mass = 0.1f;
        }
    }

    private void FixedUpdate()
    {
        if (RB.velocity.y > 3 && CanBounce)
        {
            CanBounce = false;
            RB.AddForce(transform.up * 0.1f, ForceMode.Impulse);
        }
        if (RB.velocity.y == 0)
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
            if (!IsBonus)
            {             
                LevelCrateBroken.RaiseTransform(transform);
            }
            else
            {
                BonusCrateBroken.RaiseTransform(transform);
            }
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
            if (IsWumpa || !WasLife)
            {
                AddWumpa.RaiseInt(Amount);
            }
            else
            {
                if (WasLife)
                {
                    WasLife = false;
                    AddLife.Raise();
                }
            }
        }
        else
        {
            if (IsWumpa || !WasLife)
            {
                for (int i = 0; i < Amount; i++)
                {
                    if (i > 0)
                    {
                        var x = Random.Range(-0.5f, 0.5f);
                        var z = Random.Range(-0.5f, 0.5f);
                        GameObject ItemSpawned = Instantiate(Wumpa, new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z), Quaternion.identity);
                        ItemSpawned.transform.SetParent(SpawnedItems.transform);
                    }
                    else
                    {
                        GameObject ItemSpawned = Instantiate(Wumpa, transform.position, Quaternion.identity);
                        ItemSpawned.transform.SetParent(SpawnedItems.transform);
                    }
                }
            }
            else
            {
                WasLife = false;
                GameObject ItemSpawned = Instantiate(Life, transform.position, Quaternion.identity);
                ItemSpawned.transform.SetParent(SpawnedItems.transform);
            }              
        }
        DisableCrate();
    }

    private void DelayInactive()
    {
        gameObject.SetActive(false);
    }
}
