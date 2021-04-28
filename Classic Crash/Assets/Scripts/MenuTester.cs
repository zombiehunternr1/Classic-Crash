using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTester : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("TestScene");
    }

    public void SaveGame()
    {
        GameSaveManager.Instance.SaveGame();
    }

    public void LoadGame()
    {
        GameSaveManager.Instance.LoadGame();
    }
}
