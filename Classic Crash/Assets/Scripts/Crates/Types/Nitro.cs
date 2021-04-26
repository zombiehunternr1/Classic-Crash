using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitro : MonoBehaviour, ICrateBase
{
    public ParticleSystem Explosion;
    public bool CanBounce;

    private Animator AnimNitro;
    private int SmallhopsTriggered = 0;

    private void Awake()
    {
        AnimNitro = GetComponent<Animator>();
        if (CanBounce)
        {
            StartCoroutine(RandomBounce());
        }
    }

    public void Break(int Side)
    {
        Explode();
    }

    public void Explode()
    {
        StopCoroutine(RandomBounce());
        DisableCrate();
        Instantiate(Explosion, transform.position, Quaternion.identity);
    }

    public void DisableCrate()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator RandomBounce()
    {
        float RandomCheck = Random.Range(0, 5);
        while (RandomCheck > 0)
        {
            RandomCheck -= Time.deltaTime;
            yield return RandomCheck;
        }
        float SelectRandom = Random.Range(0, 1);
        if (SelectRandom < 0.5f && SmallhopsTriggered < 5)
        {
            SmallhopsTriggered++;
            AnimNitro.SetTrigger("SmallHop");
        }
        else
        {
            SmallhopsTriggered = 0;
            AnimNitro.SetTrigger("BigHop");
        }
        StartCoroutine(RandomBounce());
    }
}
