using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private SphereCollider HitBox;
    public float ExplosionRadius = 1.5f;

    private void Awake()
    {
        HitBox = GetComponent<SphereCollider>();
        CheckExplosionRadius();
        StartCoroutine(DisableCollider());
    }

    void CheckExplosionRadius()
    {
        Collider[] hitColliders = Physics.OverlapSphere(HitBox.bounds.center, ExplosionRadius);
        foreach (var hitCollider in hitColliders)
        {
            //Get reference to the script / interface
            ICrateBase crate = (ICrateBase)hitCollider.gameObject.GetComponent(typeof(ICrateBase));
            if (crate != null)
            {
                crate.Break(10);
            }
            else if(hitCollider.gameObject.GetComponent<InputManager>())
            {
                Debug.Log("Hit player");
            }
        }
    }

    IEnumerator DisableCollider()
    {
        yield return new WaitForSeconds(0.5f);
        HitBox.enabled = false;
    }
}
