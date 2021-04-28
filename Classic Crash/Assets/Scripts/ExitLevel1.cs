using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel1 : MonoBehaviour
{
    public GameEvent SaveProgress;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<InputManager>())
        {
            SaveProgress.Raise();
            SceneManager.LoadScene("Level2");
        }
    }
}
