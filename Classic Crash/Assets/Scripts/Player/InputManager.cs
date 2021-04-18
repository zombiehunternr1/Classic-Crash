using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    public float Speed = 5;
    public float JumpForce = 7;
    public float DistanceToGround = 1.01f;
    public float SpinRadius = 1.5f;

    private int SideHitValue;
    private bool Spinning;

    private PlayerControls PlayerControls;
    private Vector2 MovementInput;
    private Rigidbody RB;
    private BoxCollider HitBox;

    private Vector3 PlayerMovement;
    private bool CanJump;

    //Enums to help check which side the player hit a certain object or with his attack.
    private enum HitPlayerDirection { None, Top, Bottom, Forward, Back, Left, Right, Spin, Invincibility }

    private void OnEnable()
    {
        if (RB == null)
        {
            RB = GetComponent<Rigidbody>();
        }
        if (HitBox == null)
        {
            HitBox = GetComponent<BoxCollider>();
        }
        if (PlayerControls == null)
        {
            PlayerControls = new PlayerControls();
            PlayerControls.Player.Movement.performed += i => MovementInput = i.ReadValue<Vector2>();
            PlayerControls.Player.Jump.performed += i => Jump();
            PlayerControls.Player.Spin.performed += i => SpinAttack();
        }
        PlayerControls.Enable();
    }

    private void OnDisable()
    {
        PlayerControls.Disable();
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        PlayerMovement = new Vector3(MovementInput.x, 0, MovementInput.y);
        RB.MovePosition(transform.position + PlayerMovement * Time.fixedDeltaTime * Speed);
        LookDirection();
    }

    private void LookDirection()
    {
        if (PlayerMovement != Vector3.zero)
        {
            transform.forward = PlayerMovement;
        }
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            RB.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
        }
    }

    private void SpinAttack()
    {
        Spinning = true;
        Collider[] hitColliders = Physics.OverlapSphere(HitBox.bounds.center, SpinRadius);
        foreach (var hitCollider in hitColliders)
        {
            //Get reference to the script / interface
            ICrateBase crate = (ICrateBase)hitCollider.gameObject.GetComponent(typeof(ICrateBase));
            if (crate != null)
            {
                crate.Break((int)ReturnDirection(gameObject, hitCollider.gameObject));
            }
        }
        Spinning = false;
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, DistanceToGround);
    }

    public void OnCollisionEnter(Collision collision)
    {
        ICrateBase crate = (ICrateBase)collision.gameObject.GetComponent(typeof(ICrateBase));
    
        ReturnDirection(gameObject, collision.gameObject);   

        if (crate != null)
        {
            crate.Break(SideHitValue);
        }
    }

    //This Enum function checks which side the player hits a certain object and returns this information.
    private HitPlayerDirection ReturnDirection(GameObject Object, GameObject ObjectHit)
    {
        HitPlayerDirection HitDirection = HitPlayerDirection.None;

        if (Spinning)
        {
            return HitPlayerDirection.Spin;
        }
        RaycastHit MyRayHit;
        Vector3 direction = (ObjectHit.transform.position - Object.transform.position).normalized;
        Ray MyRay = new Ray(Object.transform.position, direction);

        if (Physics.Raycast(MyRay, out MyRayHit))
        {
            if (MyRayHit.collider != null)
            {
                Vector3 MyNormal = MyRayHit.normal;
                MyNormal = MyRayHit.transform.TransformDirection(MyNormal);

                if (MyNormal == MyRayHit.transform.up)
                {
                    HitDirection = HitPlayerDirection.Top;
                    SideHitValue = Convert.ToInt32(HitDirection);
                }
                if (MyNormal == -MyRayHit.transform.up)
                {
                    HitDirection = HitPlayerDirection.Bottom;
                    SideHitValue = Convert.ToInt32(HitDirection);
                }
                if (MyNormal == MyRayHit.transform.forward)
                {
                    HitDirection = HitPlayerDirection.Forward;
                    SideHitValue = Convert.ToInt32(HitDirection);
                }
                if (MyNormal == -MyRayHit.transform.forward)
                {
                    HitDirection = HitPlayerDirection.Back;
                    SideHitValue = Convert.ToInt32(HitDirection);
                }
                if (MyNormal == MyRayHit.transform.right)
                {
                    HitDirection = HitPlayerDirection.Right;
                    SideHitValue = Convert.ToInt32(HitDirection);
                }
                if (MyNormal == -MyRayHit.transform.right)
                {
                    HitDirection = HitPlayerDirection.Left;
                    SideHitValue = Convert.ToInt32(HitDirection);
                }
            }
        }
        return HitDirection;
    }
}
