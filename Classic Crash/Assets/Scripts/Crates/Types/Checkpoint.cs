using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour, ICrateBase
{
    public CrateType crateType;
    public GameObject BrokenCrate;
    public GameObject MetalCrate;
    public GameEventTransform CrateBroken;
    public GameEvent SaveCrateCount;
    public AudioSource BreakSFX;
    public AudioSource CheckpointSFX;
    public AudioSource ActivatorSFX;

    [HideInInspector]
    public bool IsBonus { get; set; }
    [HideInInspector]
    public bool IsBroken;

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
        CrateBroken.RaiseTransform(transform);
        BreakSFX.Play();
        CheckpointSFX.Play();
        Instantiate(BrokenCrate, transform.position, Quaternion.identity);
        SaveProgress();
        DisableCrate();
    }

    private void UnbreakableCheckpoint()
    {
        ActivatorSFX.Play();
        CheckpointSFX.Play();
        Instantiate(MetalCrate, transform.position, Quaternion.identity);
        SaveProgress();
        DisableCrate();
    }

    private void SaveProgress()
    {
        Vector3 CheckPointPosition = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        GameManager.Instance.PlayerInfo.Player.LastCheckpointPosition = CheckPointPosition;
        SaveCrateCount.Raise();
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
