using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private SphereCollider HitBox;

    private void Awake()
    {
        HitBox = GetComponent<SphereCollider>();
        StartCoroutine(DisableCollider());
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<InputManager>())
        {
            Debug.Log("Hit player");
        }
    }

    IEnumerator DisableCollider()
    {
        yield return new WaitForSeconds(0.5f);
        HitBox.enabled = false;
    }
}
