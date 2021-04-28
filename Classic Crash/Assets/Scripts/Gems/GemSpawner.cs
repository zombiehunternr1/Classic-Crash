using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GemSpawner : MonoBehaviour
{
    public GemBase Gemtype;
    public GameEventGem GemCollected;

    private List<Renderer> GemVariants;
    private int Selected;

    private void Awake()
    {
        GetGemVariants();
    }

    private void GetGemVariants()
    {
        GemVariants = new List<Renderer>();
        Renderer[] Gems = GetComponentsInChildren<Renderer>();
        foreach (Renderer Gem in Gems)
        {
            GemVariants.Add(Gem);
        }
        SelectGemType();
    }
    private void SelectGemType()
    {
        Selected = Convert.ToInt32(Gemtype.Type);
        foreach(Renderer Gem in GemVariants)
        {
            if(Gem == GemVariants[Selected])
            {
                Gem.enabled = true;
            }
        }
    }
    public void CollectGem()
    {
        GemCollected.RaiseGem(Gemtype);
        gameObject.SetActive(false);
    }
}
