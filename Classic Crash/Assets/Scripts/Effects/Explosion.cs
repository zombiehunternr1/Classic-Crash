using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private SphereCollider HitBox;

    private void Awake()
    {
        HitBox = GetComponent<SphereCollider>();
        Destroy(gameObject, 0.5f);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<InputManager>())
        {
            Debug.Log("Hit player");
        }
    }
}
