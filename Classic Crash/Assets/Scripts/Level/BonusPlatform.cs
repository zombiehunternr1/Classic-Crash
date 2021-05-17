using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPlatform : MonoBehaviour
{
    public Transform BonusLocation;

    private void OnTriggerEnter(Collider other)
    {      
        if (other.GetComponent<InputManager>())
        {
            if (BonusLocation != null)
            {
                other.GetComponent<InputManager>().BonusArea = true;
                GameManager.Instance.StartCoroutine(GameManager.Instance.FadingEffect(BonusLocation));
            }
        }
    }
}
