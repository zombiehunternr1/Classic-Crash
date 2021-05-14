using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldmapPlayerController : MonoBehaviour
{
    public float Speed;
    [HideInInspector]
    public World CurrentWorld;
    private Transform PlayerPosition;
    private int Level;
    private Vector2 MovementInput;
    private PlayerControls PlayerControls;
    private BoxCollider HitBox;
    private bool IsMoving = false;
    private float Step;

    private void OnEnable()
    {
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
            }
            if (MovementInput.x == -1)
            {
                MoveToLevel(MovementInput);
            }
            if (MovementInput.y == 1)
            {
                MoveToLevel(MovementInput);
            }
            if (MovementInput.y == -1)
            {
                MoveToLevel(MovementInput);
            }
        }    
    }

    private void MoveToLevel(Vector2 Move)
    {
        IsMoving = true;
        if (Move == Vector2.up)
        {
            Vector3 MoveUp = Vector3.forward;
            StartCoroutine(CheckDirection(MoveUp));
        }
        if (Move == Vector2.down)
        {
            Vector3 MoveDown = -Vector3.forward;
            StartCoroutine(CheckDirection(MoveDown));
        }
        if (Move == Vector2.left)
        {
            Vector3 MoveLeft = Vector3.left;
            StartCoroutine(CheckDirection(MoveLeft));
        }
        if (Move == Vector2.right)
        {
            Vector3 MoveRight = Vector3.right;
            StartCoroutine(CheckDirection(MoveRight));
        }
    }

    private IEnumerator CheckDirection(Vector3 Direction)
    {
        RaycastHit Hit;
        float Reset = 0;
        while(Reset < 0.1)
        {
            Reset += Time.deltaTime;
            if (Physics.Raycast(PlayerPosition.position, transform.TransformDirection(Direction), out Hit))
            {
                if (Hit.collider != GetComponent<WorldmapPlayerController>())
                {
                    Route CurrentRoute = Hit.collider.GetComponentInParent<Route>();
                    Level GoToLevel = Hit.collider.GetComponent<Level>();
                    if (CurrentWorld.Routes.Contains(CurrentRoute.transform))
                    {
                        StartCoroutine(MoveToLevel(GoToLevel));
                    }
                }
            }
            yield return Reset;
        }
        IsMoving = false;
    }

    private IEnumerator MoveToLevel(Level GoToLevel)
    {
        while (PlayerPosition.position != GoToLevel.transform.position)
        {
            Step = Speed * Time.deltaTime;
            PlayerPosition.position = Vector3.MoveTowards(PlayerPosition.position, GoToLevel.transform.position, Step);
            yield return PlayerPosition.position;            
        }
        Step = 0;
        IsMoving = false;
    }
}
