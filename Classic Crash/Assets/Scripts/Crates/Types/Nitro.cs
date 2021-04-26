using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitro : MonoBehaviour, ICrateBase
{
    public ParticleSystem Explosion;
    public bool CanBounce;
    public GameEvent CrateBroken;

    private Animator AnimNitro;
    private int SmallhopsTriggered = 0;
    private float RandomCheck;

    private void Start()
    {
        AnimNitro = GetComponent<Animator>();
        if (CanBounce)
        {
            StartCoroutine(RandomHopCheck());
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
        CrateBroken.Raise();
        gameObject.SetActive(false);
    }

    private void SelectRandomHop()
    {
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
