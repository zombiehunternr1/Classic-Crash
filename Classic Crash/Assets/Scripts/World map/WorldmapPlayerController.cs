using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldmapPlayerController : MonoBehaviour
{
    [HideInInspector]
    public PlayerManager PlayerManager;

    private Vector2 MovementInput;
    private PlayerControls PlayerControls;
    private BoxCollider HitBox;
    private void OnEnable()
    {
        if (PlayerManager == null)
        {
            PlayerManager = FindObjectOfType<PlayerManager>();
        }
        if (HitBox == null)
        {
            HitBox = GetComponent<BoxCollider>();
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
