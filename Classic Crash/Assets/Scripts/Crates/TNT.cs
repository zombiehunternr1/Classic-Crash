using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour, ICrateBase
{
    private bool Started;

    private List<Renderer> SubCrates = new List<Renderer>();

    private void Awake()
    {
        foreach(Renderer TNT in gameObject.GetComponentsInChildren<Renderer>())
        {
            SubCrates.Add(TNT);
        }
        SubCrates.RemoveAt(0);
        foreach(Renderer TNT in SubCrates)
        {
            TNT.enabled = false;
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
        }
    }

    public void Explode()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator Countdown()
    {
        if (!Started)
        {
            Started = true;
            SubCrates[0].enabled = true;
            yield return new WaitForSeconds(1);
            SubCrates[0].enabled = false;
            SubCrates[1].enabled = true;
            yield return new WaitForSeconds(1);
            SubCrates[1].enabled = false;
            SubCrates[2].enabled = true;
            yield return new WaitForSeconds(1);
            Explode();
        }    
    }
}
