using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float Speed = 5;
    public float JumpForce = 7;
    public float DistanceToGround = 1.01f;

    private PlayerControls PlayerControls;
    private Vector2 MovementInput;
    private Rigidbody RB;
    private BoxCollider HitBox;

    private Vector3 PlayerMovement;
    private bool CanJump;

    private void OnEnable()
    {
        if(RB == null)
        {
            RB = GetComponent<Rigidbody>();
        }
        if(HitBox == null)
        {
            HitBox = GetComponent<BoxCollider>();
        }
        if (PlayerControls == null)
        {
            PlayerControls = new PlayerControls();
            PlayerControls.Player.Movement.performed += i => MovementInput = i.ReadValue<Vector2>();
            PlayerControls.Player.Jump.performed += i => Jump();
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
        if(PlayerMovement != Vector3.zero)
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

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, DistanceToGround);
    }
}
