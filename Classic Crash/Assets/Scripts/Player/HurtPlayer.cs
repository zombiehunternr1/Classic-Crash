using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
    public Transform BonusPlatform;
    public GameEventTransform PlayerHit;
    public bool Instakill;

    private int Scene;
    private void OnEnable()
    {
        Scene = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<InputManager>())
        {
            InputManager Player = collision.gameObject.GetComponent<InputManager>();
            if (Instakill)
            {
                if (Player.BonusArea)
                {
                    GameManager.Instance.StartCoroutine(GameManager.Instance.FadingEffect(BonusPlatform));
                    Player.BonusArea = false;
                }
                else
                {
                    Player.Instakill = true;
                    GameManager.Instance.StartCoroutine(GameManager.Instance.FadingEffect(null));
                }
            }
            else
            {
                GotHit(Player);
            }       
        }
    }

    public void GotHit(InputManager Player)
    {
        PlayerHit.RaiseTransform(Player.transform);
    }
}
