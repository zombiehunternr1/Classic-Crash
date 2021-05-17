using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BonusPlatform : MonoBehaviour
{
    public Transform BonusLocation;
    private Transform BonusEntry;
    private int CurrentLevel;
    private void OnEnable()
    {
        CurrentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter(Collider other)
    {      
        if (other.GetComponent<InputManager>())
        {
            if (BonusLocation != null)
            {
                GameManager.Instance.StartCoroutine(GameManager.Instance.FadingEffect(CurrentLevel, BonusLocation));
            }
        }
    }
}
