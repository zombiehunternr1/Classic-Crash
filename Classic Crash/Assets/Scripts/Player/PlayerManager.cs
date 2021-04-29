using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    CrateSystem CrateSystem;

    private void Awake()
    {
        CrateSystem = GetComponent<CrateSystem>();
    }

    public void PlayerHit(Transform Player)
    {
        Player.GetComponent<InputManager>().LoadLastCheckpoint();
        CrateSystem.ResetCrates();
    }
}
