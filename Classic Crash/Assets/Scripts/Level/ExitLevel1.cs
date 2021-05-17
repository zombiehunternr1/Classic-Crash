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
            int LoadScene = SceneManager.GetActiveScene().buildIndex + 1;
            SaveProgress.Raise();
            GameManager.Instance.StartCoroutine(GameManager.Instance.FadingEffect(LoadScene, null));
        }
    }
}
