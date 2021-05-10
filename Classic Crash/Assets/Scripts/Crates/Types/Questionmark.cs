using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questionmark : MonoBehaviour, ICrateBase, ISpawnable
{
    public GameObject Wumpa;
    public GameObject Life;
    public GameEvent CrateBroken;
    public GameEventInt AddWumpa;
    public GameEvent AddLife;
    public bool IsWumpa;
    public bool AutoAdd;
    public bool HasGravity;
    public int amount = 1;
    [HideInInspector]
    public bool IsBroken;

    private bool WasLife = true;
    private Rigidbody RB;
    private bool CanBounce = true;

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
            GameManager.Instance.SFXCrateBreak();
            IsBroken = true;
            CrateBroken.Raise();
            gameObject.SetActive(false);
        }
    }

    public void SpawnItem()
    {
        if (AutoAdd)
        {
            if (IsWumpa || !WasLife)
            {
                AddWumpa.RaiseInt(amount);
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
                for (int i = 0; i < amount; i++)
                {
                    if (i > 0)
                    {
                        var x = Random.Range(-0.5f, 0.5f);
                        var z = Random.Range(-0.5f, 0.5f);
                        Instantiate(Wumpa, new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(Wumpa, transform.position, Quaternion.identity);
                    }
                }
            }
            else
            {
                WasLife = false;
                Instantiate(Life, transform.position, Quaternion.identity);
            }              
        }
        DisableCrate();
    }
}
