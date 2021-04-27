using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalCrates : MonoBehaviour
{
    public GameEventTransform CheckTotal;

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
