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
        gameObject.SetActive(false);
        Instantiate(Explosion, transform.position, transform.rotation);
    }
}
