using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggertest : MonoBehaviour
{
    public bool AllowY;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<InputManager>())
        {
            Test.AllowY = AllowY;
        }
    }
}
