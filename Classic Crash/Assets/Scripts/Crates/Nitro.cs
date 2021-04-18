using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitro : MonoBehaviour, ICrateBase
{
    public void Break(int Side)
    {
        Explode();
    }

    public void Explode()
    {
        gameObject.SetActive(false);
    }
}
