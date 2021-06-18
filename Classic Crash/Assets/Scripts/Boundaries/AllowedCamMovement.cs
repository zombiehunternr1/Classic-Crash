using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowedCamMovement : MonoBehaviour
{
    public bool AllowY;
    public bool AllowZ;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<InputManager>())
        {
            LevelCam.AllowY = AllowY;
            LevelCam.AllowZ = AllowZ;
        }
    }
}
