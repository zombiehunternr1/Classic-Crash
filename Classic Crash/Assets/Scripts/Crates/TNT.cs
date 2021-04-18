using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour, ICrateBase
{
    bool Started;

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
        Debug.Log("Kaboom");
    }

    private IEnumerator Countdown()
    {
        if (!Started)
        {
            Started = true;
            Debug.Log(3);
            yield return new WaitForSeconds(1);
            Debug.Log(2);
            yield return new WaitForSeconds(1);
            Debug.Log(1);
            yield return new WaitForSeconds(1);
            Explode();
        }    
    }
}
