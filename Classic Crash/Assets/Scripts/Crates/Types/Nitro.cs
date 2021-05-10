using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitro : MonoBehaviour, ICrateBase
{
    public ParticleSystem Explosion;
    public bool CanBounce;
    public GameEvent CrateBroken;

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
    }

    public void Break(int Side)
    {
        Explode();
    }

    public void Explode()
    {
        GameManager.Instance.SFXNitroExplode();
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
                GameManager.Instance.SFXNitroSmalHop();
                SmallhopsTriggered++;
            }
        }
        else
        {
            if (CanBounce)
            {
                RB.AddForce(transform.up * 1f, ForceMode.Impulse);
                GameManager.Instance.SFXNitroBigHop();
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
