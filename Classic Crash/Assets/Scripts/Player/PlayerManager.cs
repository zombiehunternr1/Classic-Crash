using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject AkuAkuPlayerPosition;
    CrateSystem CrateSystem;
    public ItemsCollected CollectedItems;

    private InputManager Player;
    private AudioSource SFXAkuAkuSource;
    private AudioClip SFXAkaAkuAdd;
    private AudioClip SFXAkuAkuWithdraw;
    private AudioClip SFXInvinsibility;

    private bool IsInvinsible;
    private float InvinsibleTimer = 21;

    private void Awake()
    {
        CrateSystem = GetComponent<CrateSystem>();
        GetSFXAkuAku();

        if (CollectedItems.AkuAkus > 0)
        {
            AkuAkuPlayerPosition.transform.GetChild(0).gameObject.SetActive(true);
        }
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
            SFXAkuAkuSource.PlayOneShot(SFXAkaAkuAdd);
            AkuAkuPlayerPosition.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            CollectedItems.AkuAkus++;
            SFXAkuAkuSource.PlayOneShot(SFXAkaAkuAdd);
            CheckAkuAkuCount();
        }
    }

    public void CheckAkuAkuCount()
    {
        if(CollectedItems.AkuAkus == 3 && !IsInvinsible)
        {
            Debug.Log("Activate invinsibility");
            SFXAkuAkuSource.PlayOneShot(SFXInvinsibility);
            StartCoroutine(InvinsibilityTimer());
        }
        else if(CollectedItems.AkuAkus > 3)
        {
            CollectedItems.AkuAkus = 3;
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
            SFXAkuAkuSource.PlayOneShot(SFXAkuAkuWithdraw);
            AkuAkuPlayerPosition.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if(CollectedItems.AkuAkus > 0)
        {
            SFXAkuAkuSource.PlayOneShot(SFXAkuAkuWithdraw);
            Debug.Log("Temporarely Invulnerable");
        }
        else
        {
            CollectedItems.AkuAkus = 0;
            CheckLifeTotal();
        }
    }

    private void GetSFXAkuAku()
    {
        AudioSource[] AudioSources = AkuAkuPlayerPosition.GetComponents<AudioSource>();
        SFXAkuAkuSource = AudioSources[0];
        SFXAkaAkuAdd = AudioSources[0].clip;
        SFXAkuAkuWithdraw = AudioSources[1].clip;
        SFXInvinsibility = AudioSources[2].clip;
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
