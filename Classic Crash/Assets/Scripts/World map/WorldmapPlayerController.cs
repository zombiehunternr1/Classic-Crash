using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldmapPlayerController : MonoBehaviour
{
    private int Level;
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
        if (other.GetComponent<World>())
        {
            if (CurrentWorld == null)
            {
                CurrentWorld = other.GetComponent<World>();
            }
        }
        if (other.GetComponent<Level>())
        {
            Level = other.GetComponent<Level>().level;
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
        RaycastHit Hit;
        if (Move == Vector2.up)
        {

        }
        if (Move == Vector2.down)
        {

        }
        if (Move == Vector2.left)
        {

        }
        if (Move == Vector2.right)
        {
            if (Physics.Raycast(PlayerPosition.position, transform.TransformDirection(Vector2.right), out Hit))
            {
                if (Hit.collider != GetComponent<WorldmapPlayerController>())
                {
                    Route CurrentRoute = Hit.collider.GetComponentInParent<Route>();
                    Level GoToLevel = Hit.collider.GetComponent<Level>();
                    Debug.Log(CurrentRoute);
                    Debug.Log(GoToLevel);
                }
            }
        }
    }
}
