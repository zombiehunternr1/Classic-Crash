using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour, ICrateBase
{
    public CrateType crateType;
    public GameObject BrokenCrate;
    public GameObject MetalCrate;
    public GameEventInt UpdateCrateCount;
    [HideInInspector]
    public bool IsBroken;
    private float DetectionRadius = 1f;
    private int CurrentlyBrokenAmount;

    public void Break(int Side)
    {
        switch (crateType)
        {
            case CrateType.Breakable:
                if(Side <= 2)
                {
                    BreakableCheckpoint();
                }
                else if (Side == 7)
                {
                    BreakableCheckpoint();
                }
                else if (Side == 8)
                {
                    BreakableCheckpoint();
                }
            break;
            case CrateType.Unbreakable:
                if(Side <= 2)
                {
                    UnbreakableCheckpoint();
                }
                else if (Side == 7)
                {
                    UnbreakableCheckpoint();
                }
                else if (Side == 8)
                {
                    UnbreakableCheckpoint();
                }
            break;
        }
    }

    private void BreakableCheckpoint()
    {
        GameManager.Instance.SFXCrateBreak();
        GameManager.Instance.SFXCheckPoint();
        Instantiate(BrokenCrate, transform.position, Quaternion.identity);
        SaveProgress();
        DisableCrate();
    }

    private void UnbreakableCheckpoint()
    {
        GameManager.Instance.SFXActivator();
        GameManager.Instance.SFXCheckPoint();
        Instantiate(MetalCrate, transform.position, Quaternion.identity);
        SaveProgress();
        DisableCrate();
    }

    private void SaveProgress()
    {
        SavePlayerPosition();
        SaveCrateCount();
    }

    private void SavePlayerPosition()
    {
        Collider[] hitColliders = Physics.OverlapSphere(GetComponent<BoxCollider>().bounds.center, DetectionRadius);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.GetComponent<InputManager>())
            {
                Vector3 CheckPointPosition = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                hitCollider.GetComponent<InputManager>().LastSavedCheckpoint(CheckPointPosition);
            }
        }
    }

    private void SaveCrateCount()
    {
        CrateSystem AllCrates = FindObjectOfType<CrateSystem>();

        foreach (GameObject Crate in AllCrates.BreakableCrates)
        {
            if (!Crate.activeInHierarchy)
            {
                AllCrates.CurrentlyBroken.Add(Crate);
                CurrentlyBrokenAmount++;
            }
        }
        UpdateCrateCount.RaiseInt(CurrentlyBrokenAmount + 1);
    }

    public void DisableCrate()
    {
        if (!IsBroken)
        {
            IsBroken = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }

    public enum CrateType { Breakable, Unbreakable }
}
