using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldmapPlayerController : MonoBehaviour
{
    private Vector2 MovementInput;
    private PlayerControls PlayerControls;
    private BoxCollider HitBox;
    private Transform PlayerPosition;

    private void OnEnable()
    {
        if (HitBox == null)
        {
            HitBox = GetComponent<BoxCollider>();
        }
        if(PlayerPosition == null)
        {
            PlayerPosition = HitBox.transform.GetChild(transform.childCount - 1);
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

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        MovementInput = new Vector2(MovementInput.x, MovementInput.y);
    }
}
