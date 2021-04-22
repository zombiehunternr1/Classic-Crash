using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitro : MonoBehaviour, ICrateBase
{
    public ParticleSystem Explosion;

    public void Break(int Side)
    {
        Explode();
    }

    public void Explode()
    {
        DisableCrate();
        Instantiate(Explosion, transform.position, Quaternion.identity);
    }

    public void DisableCrate()
    {
        gameObject.SetActive(false);
    }
}
