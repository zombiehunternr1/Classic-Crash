using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour, IInteractable
{
    private SphereCollider HitBox;
    public float ExplosionRadius;

    private int Side;
    private AudioSource ExplosionSFX;

    private void Awake()
    {
        ExplosionSFX = GetComponent<AudioSource>();
        ExplosionSFX.Play();
        HitBox = GetComponent<SphereCollider>();
        Interacting(Side);
        StartCoroutine(DisableCollider());
    }

    public void Interacting(int Side)
    {
        Collider[] hitColliders = Physics.OverlapSphere(HitBox.bounds.center, ExplosionRadius);
        foreach (Collider hitCollider in hitColliders)
        {
            ICrateBase Crate = (ICrateBase)hitCollider.gameObject.GetComponent(typeof(ICrateBase));
            if (Crate != null)
            {
                Crate.Break(9);
            }
            IInteractable Item = (IInteractable)hitCollider.gameObject.GetComponent(typeof(IInteractable));
            if(Item != null)
            {
                if (!hitCollider.gameObject.GetComponent<Explosion>())
                {
                    Item.Interacting(9);
                }
            }
            else if (hitCollider.gameObject.GetComponent<InputManager>())
            {
                if (!hitCollider.GetComponent<InputManager>().PlayerManager.IsInvinsible)
                {
                    Debug.Log("Hit player");
                }
            }
        }
    }

    IEnumerator DisableCollider()
    {
        yield return new WaitForSeconds(0.5f);
        HitBox.enabled = false;
    }
}
