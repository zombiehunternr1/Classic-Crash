using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    public GameEvent SaveProgress;

    private int WorldMap = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<InputManager>())
        {
            GameManager.Instance.Scene = WorldMap;
            GameManager.Instance.WorldMapLocation.UnlockNextPath = true;
            SaveProgress.Raise();
            GameManager.Instance.StartCoroutine(GameManager.Instance.FadingEffect(null));
        }
    }
}
