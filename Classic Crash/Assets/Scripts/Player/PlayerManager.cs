using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public ItemsCollected CollectedItems;

    [HideInInspector]
    public bool IsInvinsible;

    private GameObject AkuAkuPlayerPosition;
    private CrateSystem CrateSystem;
    private InputManager Player;
    private float InvinsibleTimer = 21;
    private Vector3 AkuAkuOriginalPos = new Vector3(1,0,0);
    private Vector3 AkuAkuFrontFacePos = new Vector3(0, 0, 1);

    private void Awake()
    {
        CrateSystem = GetComponent<CrateSystem>();
        AkuAkuPlayerPosition = FindObjectOfType<InputManager>().GetComponentInChildren<Animator>().gameObject;
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
            GameManager.Instance.SFXAkuAkuAdd();
            AkuAkuPlayerPosition.GetComponentInChildren<MeshRenderer>().enabled = true;
        }
        else
        {
            CollectedItems.AkuAkus++;
            GameManager.Instance.SFXAkuAkuAdd();
            CheckAkuAkuCount();
        }
    }

    public void CheckAkuAkuCount()
    {
        if(CollectedItems.AkuAkus == 3 && !IsInvinsible)
        {
            GameManager.Instance.SFXInvinsibility();
            StartCoroutine(InvinsibilityTimer());
        }
        else if(CollectedItems.AkuAkus > 3)
        {
            CollectedItems.AkuAkus = 3;
        }
    }

    public void StopInvinsibility()
    {
        GameManager.Instance.SFXStopInvinsiblility();
        if (CollectedItems.AkuAkus != 0)
        {
            if (CollectedItems.AkuAkus >= 3)
            {
                CollectedItems.AkuAkus--;
            }
            if (AkuAkuPlayerPosition != null)
            {
                AkuAkuPlayerPosition.GetComponentInChildren<MeshRenderer>().enabled = true;
            }
        }
        else
        {
            AkuAkuPlayerPosition.GetComponentInChildren<MeshRenderer>().enabled = false;
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
            GameManager.Instance.SFXWithdrawAkuAku();
            AkuAkuPlayerPosition.GetComponentInChildren<MeshRenderer>().enabled = false;
        }
        else if(CollectedItems.AkuAkus > 0)
        {
            GameManager.Instance.SFXWithdrawAkuAku();
        }
        else
        {
            CollectedItems.AkuAkus = 0;
            CheckLifeTotal();
        }
    }

    private IEnumerator InvinsibilityTimer()
    {
        AkuAkuPlayerPosition.GetComponent<Animator>().enabled = false;
        AkuAkuPlayerPosition.transform.localPosition = AkuAkuFrontFacePos;
        IsInvinsible = true;
        while(InvinsibleTimer > 0)
        {
            InvinsibleTimer -= Time.deltaTime;
            yield return InvinsibleTimer;
        }
        AkuAkuPlayerPosition.transform.localPosition = AkuAkuOriginalPos;
        AkuAkuPlayerPosition.GetComponent<Animator>().enabled = true;
        IsInvinsible = false;
        CollectedItems.AkuAkus--;
    }
}
