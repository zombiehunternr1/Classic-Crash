using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalCrates : MonoBehaviour
{
    public GameEventTransform CheckTotal;
    [HideInInspector]
    public TextMeshPro BoxCrateUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<InputManager>())
        {
            CheckTotal.RaiseTransform(transform);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<InputManager>())
        {
            CheckTotal.RaiseTransform(transform);
        }
    }
    
    public void DisableTotalCrate()
    {
        gameObject.SetActive(false);
    }
}
