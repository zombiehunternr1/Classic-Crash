using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnorePlayer : MonoBehaviour
{
    private BoxCollider Hitbox;
    private void Awake()
    {
        Hitbox = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<InputManager>())
        {
            Physics.IgnoreCollision(Hitbox, collision.gameObject.GetComponent<BoxCollider>());
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<InputManager>())
        {
            Physics.IgnoreCollision(Hitbox, collision.gameObject.GetComponent<BoxCollider>());
        }
    }
}
