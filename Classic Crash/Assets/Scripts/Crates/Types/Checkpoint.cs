using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour, ICrateBase
{
    public CrateType crateType;
    public GameObject BrokenCrate;
    public GameObject MetalCrate;
    private float DetectionRadius = 1f;

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
        Instantiate(BrokenCrate, transform.position, Quaternion.identity);
        SaveProgress();
        DisableCrate();
    }

    private void UnbreakableCheckpoint()
    {
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
            }
        }
    }

    public void DisableCrate()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    public enum CrateType { Breakable, Unbreakable }
}
