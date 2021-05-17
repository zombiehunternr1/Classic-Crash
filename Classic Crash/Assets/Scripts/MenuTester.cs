using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTester : MonoBehaviour
{
    public void StartGame()
    {
        int LoadScene = SceneManager.GetActiveScene().buildIndex + 1;
        GameManager.Instance.FadeToBlack = true;
        GameManager.Instance.StartCoroutine(GameManager.Instance.FadingEffect(LoadScene, null));
    }

    public void SaveGame()
    {
        GameManager.Instance.SaveGame();
    }

    public void LoadGame()
    {
        GameManager.Instance.LoadGame();
    }
}
