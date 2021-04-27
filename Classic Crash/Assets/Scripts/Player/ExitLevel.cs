using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour
{
    public GameEvent SaveProgress;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<InputManager>())
        {
            SaveProgress.Raise();
        }
    }
}
