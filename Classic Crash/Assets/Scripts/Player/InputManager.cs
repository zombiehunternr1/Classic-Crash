using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    public float Speed = 5;
    public float RegularJump = 7;
    public float BigJump = 10;
    public float DistanceToGround = 1.01f;

    private int SideHitValue;
    private bool Spinning;
    private bool HoldJump;
    private float JumpTimer = 0.4f;

    [HideInInspector]
    public PlayerManager PlayerManager;
    [HideInInspector]
    public Transform PlayerPosition;
    [HideInInspector]
    public bool BonusArea;
    [HideInInspector]
    public bool Instakill;
    [HideInInspector]
    public Vector3 LastCheckpointPosition;
    private PlayerControls PlayerControls;
    private Vector2 MovementInput;
    private Rigidbody RB;
    private BoxCollider HitBox;

    private Vector3 PlayerMovement;

    private Vector3 LastPosition;

    private Vector3 SmallHitBox;
    private Vector3 BigHitBox;

    private Collider[] hitColliders;
    //Enums to help check which side the player hit a certain object or with his attack.
    private enum HitPlayerDirection { None, Top, Bottom, Forward, Back, Left, Right, Spin, Invincibility }

    private void OnEnable()
    {
        SmallHitBox = new Vector3(2, 0.1f, 2);
        BigHitBox = new Vector3(2, 0.5f, 2);
        if (PlayerManager == null)
        {
            PlayerManager = FindObjectOfType<PlayerManager>();
        }
        if (RB == null)
        {
            RB = GetComponent<Rigidbody>();
        }
        if (HitBox == null)
        {
            HitBox = GetComponent<BoxCollider>();
        }
        if(PlayerPosition == null)
        {
            PlayerPosition = GetComponent<Transform>();
        }
        if (PlayerControls == null)
        {
            PlayerControls = new PlayerControls();
            PlayerControls.Level.Movement.performed += i => MovementInput = i.ReadValue<Vector2>();
            PlayerControls.Level.JumpPressed.performed += i => JumpPressed();
            PlayerControls.Level.JumpReleased.performed += i => JumpReleased();
            PlayerControls.Level.Spin.performed += i => SpinAttack();
        }
        PlayerControls.Enable();
        LastSavedCheckpoint(transform.position);
        LastPosition = transform.position + PlayerMovement;
    }

    private void OnDisable()
    {
        PlayerControls.Disable();
    }

    private void Update()
    {
        if (GameManager.Instance.CanMove)
        {
            Movement();
            JumpingTImer();
        }
    }

    private void Movement()
    {
        PlayerMovement = new Vector3(MovementInput.x, 0, MovementInput.y);
        LastPosition = transform.position + PlayerMovement;
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

    private void JumpingTImer()
    {
        if (HoldJump)
        {
            if(JumpTimer >= 0)
            {
                JumpTimer -= Time.deltaTime;
            }
        }
        else
        {
            JumpTimer = 0.4f;
        }
    }

    public void Jumping()
    {
        if(JumpTimer >= 0)
        {
            JumpTimer = 0.4f;
            RB.AddForce(new Vector3(0, RegularJump, 0), ForceMode.Impulse);
            return;
        }
        else
        {
            JumpTimer = 0.4f;
            RaycastHit MyRayHit;
            if(Physics.Raycast(transform.position, -Vector3.up, out MyRayHit))
            {
                if(MyRayHit.collider != null)
                {
                    Bounce BounceCrate = MyRayHit.collider.GetComponent<Bounce>();
                    if(BounceCrate != null)
                    {
                        BounceCrate.BounceObject(RB, BigJump);
                        return;
                    }
                }
                RB.AddForce(new Vector3(0, RegularJump, 0), ForceMode.Impulse);
            }
        }
    }

    private void JumpPressed()
    {
        HoldJump = true;
        
    }

    private void JumpReleased()
    {
        HoldJump = false;
        if (IsGrounded())
        {
            Jumping();
        }
    }

    private void SpinAttack()
    {
        Spinning = true;
        if (transform.position == LastPosition)
        {
            hitColliders = Physics.OverlapBox(HitBox.bounds.center, SmallHitBox);
        }
        else
        {
            hitColliders = Physics.OverlapBox(HitBox.bounds.center, BigHitBox);
        }

        foreach (var hitCollider in hitColliders)
        {
            ICrateBase Crate = (ICrateBase)hitCollider.gameObject.GetComponent(typeof(ICrateBase));
            if (Crate != null)
            {
                Crate.Break((int)ReturnDirection(gameObject, hitCollider.gameObject));
            }
            IInteractable Item = (IInteractable)hitCollider.gameObject.GetComponent(typeof(IInteractable));
            if (Item != null)
            {
                Item.Interacting((int)ReturnDirection(gameObject, hitCollider.gameObject));
            }
            HurtPlayer Player = hitCollider.GetComponent<HurtPlayer>();
            if (Player != null)
            {
                Player.GotHit(this);
            }
        }
        RaycastHit MyRayHit;
        if (Physics.Raycast(transform.position, -Vector3.up, out MyRayHit))
        {
            if (MyRayHit.collider != null)
            {
                ICrateBase crate = (ICrateBase)MyRayHit.collider.GetComponent(typeof(ICrateBase));
                if (crate != null)
                {
                    crate.Break((int)ReturnDirection(gameObject, MyRayHit.collider.gameObject));
                }
            }
        }
        Spinning = false;
    }

    public void LastSavedCheckpoint(Vector3 Position)
    {
        if(LastCheckpointPosition == null)
        {
            LastCheckpointPosition = transform.position;
            return;
        }
        else
        {
            LastCheckpointPosition = Position;
        }
    }

    public void LoadLastCheckpoint()
    {
        transform.position = LastCheckpointPosition;
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, DistanceToGround);
    }

    public void OnCollisionEnter(Collision collision)
    {
        ICrateBase crate = (ICrateBase)collision.gameObject.GetComponent(typeof(ICrateBase));    
        if (crate != null)
        {
            crate.Break((int)ReturnDirection(gameObject, collision.gameObject));
        }
        IInteractable Item = (IInteractable)collision.gameObject.GetComponent(typeof(IInteractable));
        if (Item != null)
        {
            Item.Interacting((int)ReturnDirection(gameObject, collision.gameObject));
        }
    }

    //This Enum function checks which side the player hits a certain object and returns this information.
    private HitPlayerDirection ReturnDirection(GameObject Object, GameObject ObjectHit)
    {
        HitPlayerDirection HitDirection = HitPlayerDirection.None;

        if (PlayerManager.IsInvinsible)
        {
            return HitPlayerDirection.Invincibility;
        }
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
