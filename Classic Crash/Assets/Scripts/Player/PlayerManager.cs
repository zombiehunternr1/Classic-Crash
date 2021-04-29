using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    CrateSystem CrateSystem;
    public ItemsCollected CollectedItems;

    private bool IsGameOver;

    private void Awake()
    {
        IsGameOver = false;
        CrateSystem = GetComponent<CrateSystem>();
    }

    public void PlayerHit(Transform Player)
    {
        CheckLifeTotal();
        if (IsGameOver)
        {
            GameOver();
        }
        else
        {
            Player.GetComponent<InputManager>().LoadLastCheckpoint();
            CrateSystem.ResetCrates();
        }
    }

    public void AddWumpa(int Amount)
    {
        if (CollectedItems.Wumpa >= 99)
        {
            CollectedItems.Wumpa = 0;
            AddLife();
        }
        else
        {
            CollectedItems.Wumpa += Amount;
        }
    }

    public void AddLife()
    {
        CollectedItems.Lives++;
    }

    public void CheckLifeTotal()
    {
        if (CollectedItems.Lives > 0)
        {
            CollectedItems.Lives--;
            IsGameOver = false;
        }
        else
        {
            IsGameOver = true;
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }
}
