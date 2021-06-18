using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggertest : MonoBehaviour
{
    public bool AllowY;
    public bool AllowZ;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<InputManager>())
        {
            Test.AllowY = AllowY;
            Test.AllowZ = AllowZ;
        }
    }
}
