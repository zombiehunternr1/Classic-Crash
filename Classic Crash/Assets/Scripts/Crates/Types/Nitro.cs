using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitro : MonoBehaviour, ICrateBase
{
    public ParticleSystem Explosion;
    public bool CanBounce;
    public GameEvent CrateBroken;
    public AudioSource SmalHopSFX;
    public AudioSource BigHopSFX;

    [HideInInspector]
    public bool IsBroken;
    private int SmallhopsTriggered = 0;
    private float RandomCheck;
    private Rigidbody RB;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        if (CanBounce)
        {
            StartCoroutine(RandomHopCheck());
        }
        else
        {
            RB.constraints = RigidbodyConstraints.FreezeAll;
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
            CrateBroken.Raise();
            gameObject.SetActive(false);
        }
    }

    private void SelectRandomHop()
    {
        float SelectRandom = Random.Range(0, 1);
        if (SelectRandom < 0.5f && SmallhopsTriggered < 5)
        {
            if (CanBounce)
            {
                RB.AddForce(transform.up * 0.5f, ForceMode.Impulse);
                SmalHopSFX.Play();
                SmallhopsTriggered++;
            }
        }
        else
        {
            if (CanBounce)
            {
                RB.AddForce(transform.up * 0.7f, ForceMode.Impulse);
                BigHopSFX.Play();
                SmallhopsTriggered = 0;
            }
        }
    }

    private IEnumerator RandomHopCheck()
    {
        RandomCheck = Random.Range(0, 5);
        while (RandomCheck > 0)
        {
            RandomCheck -= Time.deltaTime;
            yield return RandomCheck;
        }
        SelectRandomHop();
        StartCoroutine(RandomHopCheck());
    }
}
