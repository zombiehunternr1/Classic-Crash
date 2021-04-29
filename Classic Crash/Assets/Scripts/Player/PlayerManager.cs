using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    CrateSystem CrateSystem;
    public ItemsCollected CollectedItems;

    private void Awake()
    {
        CrateSystem = GetComponent<CrateSystem>();
    }

    public void PlayerHit(Transform Player)
    {
        WithdrawLife();
        Player.GetComponent<InputManager>().LoadLastCheckpoint();
        CrateSystem.ResetCrates();
    }

    public void AddWumpa()
    {
        if (CollectedItems.Wumpa >= 99)
        {
            CollectedItems.Wumpa = 0;
            AddLife();
        }
        else
        {
            CollectedItems.Wumpa++;
        }
    }

    public void AddLife()
    {
        CollectedItems.Lives++;
    }

    public void WithdrawLife()
    {
        if(CollectedItems.Lives > 0)
        {
            CollectedItems.Lives--;
        }
        else
        {
            Debug.Log("Game Over");
        }
    }
}
