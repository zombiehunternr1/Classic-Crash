using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour, ICrateBase
{
    public ParticleSystem Explosion;
    private bool Started;
    private List<Renderer> SubCrates = new List<Renderer>();

    private void Awake()
    {
        foreach(Renderer TNT in gameObject.GetComponentsInChildren<Renderer>())
        {
            SubCrates.Add(TNT);
        }
    }

    public void Break(int Side)
    {
        switch (Side)
        {
            case 1:
                StartCoroutine(Countdown());
                break;
            case 2:
                StartCoroutine(Countdown());
                break;
            case 7:
                Explode();
                break;
            case 10:
                Explode();
                break;
        }
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

    private IEnumerator Countdown()
    {
        if (!Started)
        {
            Started = true;
            SubCrates[0].enabled = false;
            SubCrates[1].enabled = true;
            SubCrates[1].material.EnableKeyword("_EMISSION");
            yield return new WaitForSeconds(0.2f);
            SubCrates[1].material.DisableKeyword("_EMISSION");
            yield return new WaitForSeconds(1);
            SubCrates[1].enabled = false;
            SubCrates[2].enabled = true;
            SubCrates[2].material.EnableKeyword("_EMISSION");
            yield return new WaitForSeconds(0.2f);
            SubCrates[2].material.DisableKeyword("_EMISSION");
            yield return new WaitForSeconds(1);
            SubCrates[2].enabled = false;
            SubCrates[3].enabled = true;
            SubCrates[3].material.EnableKeyword("_EMISSION");
            yield return new WaitForSeconds(0.2f);
            SubCrates[3].material.DisableKeyword("_EMISSION");
            yield return new WaitForSeconds(1);
            Explode();
        }    
    }
}
