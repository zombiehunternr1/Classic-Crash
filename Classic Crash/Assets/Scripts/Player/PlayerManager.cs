using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject AkuAkuPlayerPosition;
    CrateSystem CrateSystem;
    public ItemsCollected CollectedItems;

    private bool IsGameOver;
    private InputManager Player;

    private void Awake()
    {
        IsGameOver = false;
        CrateSystem = GetComponent<CrateSystem>();
        if(CollectedItems.AkuAkus > 0)
        {
            AkuAkuPlayerPosition.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void PlayerHit(Transform PlayerHit)
    {
        Player = PlayerHit.GetComponent<InputManager>();
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
            if(CollectedItems.AkuAkus == 0)
            {
                AkuAkuPlayerPosition.transform.GetChild(0).gameObject.SetActive(true);
            }
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
            if(CollectedItems.AkuAkus == 0)
            {
                AkuAkuPlayerPosition.transform.GetChild(0).gameObject.SetActive(false);
            }
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
            Player.LoadLastCheckpoint();
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
