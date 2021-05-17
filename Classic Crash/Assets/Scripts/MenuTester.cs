using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTester : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.Scene = SceneManager.GetActiveScene().buildIndex + 1;
        GameManager.Instance.FadeToBlack = true;
        GameManager.Instance.StartCoroutine(GameManager.Instance.FadingEffect(null));
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
