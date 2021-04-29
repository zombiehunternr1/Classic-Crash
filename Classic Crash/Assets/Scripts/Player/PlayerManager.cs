using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    CrateSystem CrateSystem;
    public ItemsCollected CollectedItems;

    private bool IsGameOver;
    private InputManager LastCheckPoint;

    private void Awake()
    {
        IsGameOver = false;
        CrateSystem = GetComponent<CrateSystem>();
    }

    public void PlayerHit(Transform Player)
    {
        LastCheckPoint = Player.GetComponent<InputManager>();
        CheckAkuAkuCount();
        if (IsGameOver)
        {
            GameOver();
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

    public void AddAkuAku()
    {
        if(CollectedItems.AkuAkus < 3)
        {
            CollectedItems.AkuAkus++;
        }
        else
        {
            Debug.Log("Invinsibility mode");
        }
    }

    public void CheckAkuAkuCount()
    {
        if(CollectedItems.AkuAkus == 3)
        {
            Debug.Log("Activate invinsibility");
        }
        else if(CollectedItems.AkuAkus != 0)
        {
            CollectedItems.AkuAkus--;
            Debug.Log("Temporarely invulnerability");
        }
        else
        {
            CheckLifeTotal();
        }
    }

    public void CheckLifeTotal()
    {
        if (CollectedItems.Lives > 0)
        {
            CollectedItems.Lives--;
            CollectedItems.AkuAkus = 0;
            IsGameOver = false;
            LastCheckPoint.LoadLastCheckpoint();
            CrateSystem.ResetCrates();
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
