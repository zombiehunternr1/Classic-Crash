using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Gemsystem : MonoBehaviour
{
    public GameObject CrateGem;
    public GameEvent DisableTotalCrates;
    public ItemsCollected CollectedItems;
    public AllGems AllGemsAvailable;

    [HideInInspector]
    public List<GemBase> GemsCollected;
    [HideInInspector]
    public List<GemBase> GemsInLevel;
    [HideInInspector]
    public List<GemSpawner> GemSpawnersInLevel;

    public int Level;

    private void Start()
    {
        Level = SceneManager.GetActiveScene().buildIndex;
        GetCollectedGems();
        GetAllGemSpawnersInLevel();
        CheckGemsCollected();
    }

    private void GetCollectedGems()
    {
        GemsCollected = new List<GemBase>();
        foreach (GemBase Gem in CollectedItems.GemsCollected)
        {
            GemsCollected.Add(Gem);
        }
    }

    private void GetAllGemSpawnersInLevel()
    {
        GemSpawner[] GemSpawner = FindObjectsOfType<GemSpawner>();
        foreach(GemSpawner Spawner in GemSpawner)
        {
            GemSpawnersInLevel.Add(Spawner);
        }
        GetAllGemsInLevel();
    }

    private void GetAllGemsInLevel()
    {
        foreach(GemSpawner Spawner in GemSpawnersInLevel)
        {
            GemsInLevel.Add(Spawner.Gemtype);
        }
    }

    private void CheckGemsCollected()
    {
        foreach (GemBase CollectedGem in GemsCollected)
        {
            if (GemsInLevel.Contains(CollectedGem))
            {    
                if(CollectedGem.Level == Level)
                {
                    if (CollectedGem.Type == GemBase.GemColor.BoxCrate)
                    {
                        foreach (GemSpawner Spawner in GemSpawnersInLevel)
                        {
                            if (Spawner.Gemtype.Type == GemBase.GemColor.BoxCrate)
                            {
                                Spawner.gameObject.SetActive(false);
                                DisableTotalCrates.Raise();
                            }
                        }
                    }
                    if (CollectedGem.Type == GemBase.GemColor.Orange)
                    {
                        foreach (GemSpawner Spawner in GemSpawnersInLevel)
                        {
                            if (Spawner.Gemtype.Type == GemBase.GemColor.Orange)
                            {
                                Spawner.gameObject.SetActive(false);
                            }
                        }
                    }
                }                   
            }
        }
    }

    public void SpawnGem(Transform location)
    {
        if (location.gameObject.GetComponent<TotalCrates>())
        {
            var TotalCrates = location.gameObject.GetComponent<TotalCrates>();
            CrateGem.transform.position = location.position;
            TotalCrates.gameObject.SetActive(false);
        }
    }

    public void GemCollected(GemBase GemType)
    {
        GemsCollected.Add(GemType);
    }

    public void SaveGemsCollected()
    {
        CollectedItems.GemsCollected = GemsCollected;
    }
}
