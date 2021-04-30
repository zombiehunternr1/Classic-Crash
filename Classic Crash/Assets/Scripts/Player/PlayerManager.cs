using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public ItemsCollected CollectedItems;

    private GameObject AkuAkuPlayerPosition;
    private GameSaveManager GameManager;
    private CrateSystem CrateSystem;
    private InputManager Player;
    private SFXAkuAku SFXAkuAku;

    private bool IsInvinsible;
    private float InvinsibleTimer = 21;

    private void Awake()
    {
        CrateSystem = GetComponent<CrateSystem>();
        AkuAkuPlayerPosition = FindObjectOfType<Animator>().gameObject;
        GameManager = FindObjectOfType<GameSaveManager>();

        SFXAkuAku = GameManager.GetComponentInChildren<SFXAkuAku>();
        StopInvinsibility();       
    }

    public void PlayerHit(Transform PlayerHit)
    {
        Player = PlayerHit.GetComponent<InputManager>();
        if (!IsInvinsible)
        {
            WithdrawAkuAku();
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
        if (CollectedItems.AkuAkus == 0)
        {
            CollectedItems.AkuAkus++;
            SFXAkuAku.PlayAddSFX();
            AkuAkuPlayerPosition.transform.GetChild(AkuAkuPlayerPosition.transform.childCount - 1).GetComponent<Renderer>().enabled = true;
        }
        else
        {
            CollectedItems.AkuAkus++;
            SFXAkuAku.PlayAddSFX();
            CheckAkuAkuCount();
        }
    }

    public void CheckAkuAkuCount()
    {
        if(CollectedItems.AkuAkus == 3 && !IsInvinsible)
        {
            Debug.Log("Activate invinsibility");
            SFXAkuAku.PlayInvinsibilitySFX();
            StartCoroutine(InvinsibilityTimer());
        }
        else if(CollectedItems.AkuAkus > 3)
        {
            CollectedItems.AkuAkus = 3;
        }
    }

    public void StopInvinsibility()
    {
        SFXAkuAku.StopInvinsibilitySFX();
        if (CollectedItems.AkuAkus != 0)
        {
            if (CollectedItems.AkuAkus == 3)
            {
                CollectedItems.AkuAkus--;
            }
            if(AkuAkuPlayerPosition != null)
            {
                AkuAkuPlayerPosition.transform.GetChild(AkuAkuPlayerPosition.transform.childCount - 1).GetComponent<Renderer>().enabled = true;
            }
        }
        else
        {
            if(AkuAkuPlayerPosition != null)
            {
                AkuAkuPlayerPosition.transform.GetChild(AkuAkuPlayerPosition.transform.childCount - 1).GetComponent<Renderer>().enabled = false;
            }
        }
    }

    private void CheckLifeTotal()
    {
        if (CollectedItems.Lives > 0)
        {
            CollectedItems.Lives--;
            CollectedItems.AkuAkus = 0;
            Player.LoadLastCheckpoint();
            CrateSystem.ResetCrates();
        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
    }

    private void WithdrawAkuAku()
    {
        CollectedItems.AkuAkus--;
        if (CollectedItems.AkuAkus == 0)
        {
            SFXAkuAku.PlayWithdrawSFX();
            AkuAkuPlayerPosition.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if(CollectedItems.AkuAkus > 0)
        {
            SFXAkuAku.PlayWithdrawSFX();
            Debug.Log("Temporarely Invulnerable");
        }
        else
        {
            CollectedItems.AkuAkus = 0;
            CheckLifeTotal();
        }
    }

    private IEnumerator InvinsibilityTimer()
    {
        IsInvinsible = true;
        while(InvinsibleTimer > 0)
        {
            InvinsibleTimer -= Time.deltaTime;
            yield return InvinsibleTimer;
        }
        IsInvinsible = false;
        CollectedItems.AkuAkus--;
    }
}
