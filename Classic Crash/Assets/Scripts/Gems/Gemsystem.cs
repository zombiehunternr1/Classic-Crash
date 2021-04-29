using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Gemsystem : MonoBehaviour
{
    public GameObject CrateGem;
    public GameEvent DisableTotalCrates;
    public ItemsCollected CollectedGems;
    public AllGems AllGemsAvailable;

    [HideInInspector]
    public List<GemBase> GemsCollected;
    [HideInInspector]
    public List<GemBase> GemsInLevel;
    [HideInInspector]
    public List<GemSpawner> GemSpawnersInLevel;

    private int Level;
    private int[] GemTypes;
    private int Selected;
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
        foreach (GemBase Gem in CollectedGems.GemsCollected)
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
                    DisableGemTypeSpawner(CollectedGem);
                }                   
            }
        }
    }

    private void DisableGemTypeSpawner(GemBase Gem)
    {
        GemTypes = Array.ConvertAll((int[])Enum.GetValues(typeof(GemBase.GemColor)), Convert.ToInt32);
        Selected = Convert.ToInt32(Gem.Type);
        
        foreach(GemSpawner Spawner in GemSpawnersInLevel)
        {
            if (GemTypes[Selected] == Convert.ToInt32(Spawner.Gemtype.Type))
            {
                if(Spawner.Gemtype.Type == GemBase.GemColor.BoxCrate)
                {
                    Spawner.gameObject.SetActive(false);
                    DisableTotalCrates.Raise();
                }
                else
                {
                    Spawner.gameObject.SetActive(false);
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
        CollectedGems.GemsCollected = GemsCollected;
    }
}
