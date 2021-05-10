using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalCrates : MonoBehaviour
{
    public GameEventTransform CheckTotal;
    public Text BoxCrateUI;

    private void Start()
    {
        Vector3 CratePos = Camera.main.WorldToScreenPoint(this.transform.position);
        BoxCrateUI.transform.position = CratePos;
    }


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
