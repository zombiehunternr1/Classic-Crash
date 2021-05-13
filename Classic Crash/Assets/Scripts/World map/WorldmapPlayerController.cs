using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldmapPlayerController : MonoBehaviour
{
    private Vector2 MovementInput;
    private PlayerControls PlayerControls;
    private BoxCollider HitBox;
    private Transform PlayerPosition;
    private World CurrentWorld;
    private bool IsMoving = false;

    private void OnEnable()
    {
        if (HitBox == null)
        {
            HitBox = GetComponentInChildren<BoxCollider>();
        }
        if(PlayerPosition == null)
        {
            PlayerPosition = HitBox.transform;
        }
        if (PlayerControls == null)
        {
            PlayerControls = new PlayerControls();
            PlayerControls.WorldMap.Movement.performed += i => MovementInput = i.ReadValue<Vector2>();
        }
        PlayerControls.Enable();
    }
    private void OnDisable()
    {
        PlayerControls.Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<World>())
        {
            if (CurrentWorld == null)
            {
                CurrentWorld = other.gameObject.GetComponent<World>();
            }
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        MovementInput = new Vector2(MovementInput.x, MovementInput.y);
        if (!IsMoving)
        {
            if (MovementInput.x == 1)
            {
                MoveToLevel(MovementInput);
                Debug.Log("right");
                IsMoving = true;
            }
            if (MovementInput.x == -1)
            {
                MoveToLevel(MovementInput);
                Debug.Log("Left");
                IsMoving = true;
            }
            if (MovementInput.y == 1)
            {
                MoveToLevel(MovementInput);
                Debug.Log("Up");
                IsMoving = true;
            }
            if (MovementInput.y == -1)
            {
                MoveToLevel(MovementInput);
                Debug.Log("Down");
                IsMoving = true;
            }
        }    
    }

    private void MoveToLevel(Vector2 Move)
    {
        //if(Move == )
        Debug.Log(Move);
    }
}
