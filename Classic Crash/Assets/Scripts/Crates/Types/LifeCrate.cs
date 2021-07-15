using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCrate : MonoBehaviour, ICrateBase
{
    public GameObject Life;
    public GameObject Wumpa;
    public GameObject BrokenEffect;
    public GameObject SpawnedItems;
    public GameEvent AddLife;
    public GameEventInt AddWumpa;
    public GameEventTransform CrateBroken;
    public int Amount = 10;
    public bool AutoAdd;
    public bool HasGravity;

    [HideInInspector]
    public bool IsBonus { get; set; }
    [HideInInspector]
    public List<Renderer> CrateTypes;
    private bool IsBroken;
    private bool WasLife;
    private Rigidbody RB;
    private bool CanBounce = true;
    private AudioSource BreakSFX;

    public void Break(int Side)
    {
        if(Side <= 2)
            SpawnLife();
        else if(Side == 7)
            SpawnLife();
        else if(Side == 8)
        {
            AutoAdd = true;
            SpawnLife();
        }
        else if(Side == 9)
        {
            DisableCrate();   
        }
    }

    private void Awake()
    {
        Renderer[] CrateType = GetComponentsInChildren<Renderer>();
        foreach(MeshRenderer Crate in CrateType)
        {
            CrateTypes.Add(Crate);
        }
        CrateTypes[CrateTypes.Count - 1].enabled = false;
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
            foreach(Renderer Mesh in CrateTypes)
            {
                Mesh.enabled = false;
            }
            BreakSFX.Play();
            IsBroken = true;
            WasLife = true;
            CrateBroken.RaiseTransform(transform);
        }
    }
    public void ResetCrate()
    {
        GetComponent<BoxCollider>().enabled = true;
        foreach (Renderer Mesh in CrateTypes)
        {
            Mesh.enabled = false;
        }
        CrateTypes[CrateTypes.Count - 1].enabled = true;
        IsBroken = false;
    }

    private void DelayInactive()
    {
        gameObject.SetActive(false);
    }

    private void SpawnLife()
    {
        if (AutoAdd)
        {
            if (WasLife)
            {
                AddWumpa.RaiseInt(Amount);
            }
            AddLife.Raise();
        }
        else
        {
            if (WasLife)
            {
                for (int i = 0; i < Amount; i++)
                {
                    if (i > 0)
                    {
                        var x = Random.Range(-0.5f, 0.5f);
                        var z = Random.Range(-0.5f, 0.5f);
                        GameObject SpawnItem = Instantiate(Wumpa, new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z), Quaternion.identity);
                        SpawnItem.transform.SetParent(SpawnedItems.transform);
                    }
                    else
                    {
                        GameObject SpawnItem = Instantiate(Wumpa, transform.position, Quaternion.identity);
                        SpawnItem.transform.SetParent(SpawnedItems.transform);
                    }
                }
            }
            else
            {
                GameObject ItemSpawned = Instantiate(Life, transform.position, Quaternion.identity);
                ItemSpawned.transform.SetParent(SpawnedItems.transform);
            }
        }
        DisableCrate();
    }
}
