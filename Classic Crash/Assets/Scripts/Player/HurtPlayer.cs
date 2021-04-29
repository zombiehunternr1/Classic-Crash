using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public GameEventTransform PlayerHit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<InputManager>())
        {
            InputManager Player = collision.gameObject.GetComponent<InputManager>();
            GotHit(Player);           
        }
    }

    public void GotHit(InputManager Player)
    {
        PlayerHit.RaiseTransform(Player.transform);
    }
}
