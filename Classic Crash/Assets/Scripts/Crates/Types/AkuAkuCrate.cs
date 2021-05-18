using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkuAkuCrate : MonoBehaviour, ICrateBase
{
    public GameObject AkuAku;
    public bool AutoAdd;
    public bool HasGravity;
    public GameEventTransform CrateBroken;
    public GameEvent AddAkuAku;

    [HideInInspector]
    public bool IsBonus { get; set; }
    private bool IsBroken;
    private Rigidbody RB;
    private bool CanBounce = true;
    private AudioSource BreakSFX;

    public void Break(int Side)
    {
        if (Side <= 2)
            SpawnAkuAku();
        else if (Side == 7)
            SpawnAkuAku();
        else if (Side == 8)
        {
            AutoAdd = true;
            SpawnAkuAku();
        }
        else if (Side == 9)
        {
            DisableCrate();
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

    private void SpawnAkuAku()
    {
        if (AutoAdd)
        {
            AddAkuAku.Raise();
        }
        else
        {
            Instantiate(AkuAku, transform.position, Quaternion.identity);
        }
        DisableCrate();
    }

    private void DelayInactive()
    {
        gameObject.SetActive(false);
    }
}
