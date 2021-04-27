using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gemsystem : MonoBehaviour
{
    public GameObject CrateGem;
    public GameEvent DisableTotalCrates;

    public List<Gem> GemsCollected;
    public List<Gem> GemsInLevel;

    private void Awake()
    {
        GetAllGemsInLevel();     
    }

    private void GetAllGemsInLevel()
    {
        Gem[] GemsFound = FindObjectsOfType<Gem>();
        foreach (Gem Gem in GemsFound)
        {
            GemsInLevel.Add(Gem);
        }
        CheckGemsCollected();
    }

    private void CheckGemsCollected()
    {
        foreach (Gem CollectedGem in GemsCollected)
        {
            if (GemsInLevel.Contains(CollectedGem))
            {
                if (CollectedGem.GemType == Gem.GemColor.BoxCrate)
                {
                    CollectedGem.gameObject.SetActive(false);
                    DisableTotalCrates.Raise();
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

    public void GemCollected(Gem Gem)
    {
        GemsCollected.Add(Gem);
        Gem.gameObject.SetActive(false);
    }
}
