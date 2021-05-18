using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitro : MonoBehaviour, ICrateBase
{
    public ParticleSystem Explosion;
    public bool CanBounce;
    public bool AllowGravity;
    public GameEventTransform CrateBroken;
    public AudioSource SmalHopSFX;
    public AudioSource BigHopSFX;

    [HideInInspector]
    public bool IsBonus { get; set; }
    [HideInInspector]
    public bool IsBroken;
    private int SmallhopsTriggered = 0;
    private float RandomCheck;
    private Rigidbody RB;
    private bool WasBounceCrate;
    private bool WasGravityCrate;
    private bool CanSingleBounce = true;

    private void Start()
    {
        WasBounceCrate = CanBounce;
        WasGravityCrate = AllowGravity;
        RB = GetComponent<Rigidbody>();
        if (CanBounce)
        {
            RB.useGravity = true;
            StartCoroutine(RandomHopCheck());
        }
        else
        {
            if (AllowGravity)
            {
                RB.useGravity = true;
                RB.mass = 0.15f;
                StartCoroutine(CheckVeloty());
            }
            else
            {
                RB.useGravity = false;
                RB.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }

    public void Break(int Side)
    {
        Explode();
    }

    public void Explode()
    {
        StopCoroutine(RandomHopCheck());
        DisableCrate();
        Instantiate(Explosion, transform.position, Quaternion.identity);
    }

    public void DisableCrate()
    {
        if (!IsBroken)
        {
            IsBroken = true;
            CrateBroken.RaiseTransform(transform);
            gameObject.SetActive(false);
        }
    }

    public void ResetCrate()
    {
        IsBroken = false;
        if (WasBounceCrate)
        {
            StartCoroutine(RandomHopCheck());
        }
        if (WasGravityCrate)
        {
            StartCoroutine(CheckVeloty());
        }
    }

    private void SelectRandomHop()
    {
        float SelectRandom = Random.Range(0, 1);
        if (SelectRandom < 0.5f && SmallhopsTriggered < 5)
        {
            if (CanBounce)
            {
                RB.mass = 0.5f;
                RB.AddForce(transform.up * 1f, ForceMode.Impulse);
                SmalHopSFX.Play();
                SmallhopsTriggered++;
            }
        }
        else
        {
            if (CanBounce)
            {
                RB.mass = 0.2f;
                RB.AddForce(transform.up * 1f, ForceMode.Impulse);
                BigHopSFX.Play();
                SmallhopsTriggered = 0;
            }
        }
    }

    private IEnumerator CheckVeloty()
    {

        while (AllowGravity)
        {
            if(RB.velocity.y > 1)
            {
                if (CanSingleBounce)
                {
                    CanSingleBounce = false;
                    RB.AddForce(transform.up * 0.1f, ForceMode.Impulse);
                }
            }
            if(RB.velocity.y == 0)
            {
                CanSingleBounce = true;
            }
            yield return null;
        }
    }

    private IEnumerator RandomHopCheck()
    {
        RandomCheck = Random.Range(0, 5);
        while (RandomCheck > 0)
        {
            if (RB.velocity.y > 0.5 || RB.velocity.y < -0.5)
            {
                CanBounce = false;
            }
            else
            {
                CanBounce = true;
            }
            RandomCheck -= Time.deltaTime;
            yield return RandomCheck;
        }
        SelectRandomHop();
        StartCoroutine(RandomHopCheck());
    }
}
