using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCrate : MonoBehaviour, IInteractable
{
    public float BounceForce = 7;
    public bool CanHit;

    private Rigidbody RB;

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }
    public void Interacting(int Side)
    {
        if(Side == 2)
        {
            CheckVelocity();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        CheckVelocity();
    }

    private void Update()
    {
        if(RB.velocity.y < 0)
        {
            CanHit = true;
        }
        else
        {
            CanHit = false;
        }
    }

    private void CheckVelocity()
    {
        RaycastHit MyRayHit;
        if (Physics.Raycast(transform.position, -Vector3.up, out MyRayHit))
        {
            if (MyRayHit.collider != null)
            {
                Bounce Crate = MyRayHit.collider.GetComponent<Bounce>();
                if (Crate != null)
                {
                    Crate.BounceObject(RB, BounceForce);
                }
                InputManager Player = MyRayHit.collider.GetComponent<InputManager>();
                if(Player != null)
                {
                    if (CanHit)
                    {
                        StartCoroutine(TempDisable(Player));
                        Debug.Log("Hit player");
                    }
                }
            }
        }
    }
    IEnumerator TempDisable(InputManager Player)
    {
        Physics.IgnoreCollision(gameObject.GetComponent<BoxCollider>(), Player.gameObject.GetComponent<BoxCollider>());
        yield return new WaitForSeconds(2);
        Physics.IgnoreCollision(gameObject.GetComponent<BoxCollider>(), Player.gameObject.GetComponent<BoxCollider>(), false);
    }
}
