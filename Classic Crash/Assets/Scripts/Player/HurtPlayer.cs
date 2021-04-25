using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    CrateSystem CrateSystem;

    private void Awake()
    {
        CrateSystem = FindObjectOfType<CrateSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<InputManager>())
        {
            InputManager Player = collision.gameObject.GetComponent<InputManager>();
            PlayerHit(Player);
        }
    }

    public void PlayerHit(InputManager Player)
    {
        Player.LoadLastCheckpoint();
        CrateSystem.ResetCrates();
    }
}
