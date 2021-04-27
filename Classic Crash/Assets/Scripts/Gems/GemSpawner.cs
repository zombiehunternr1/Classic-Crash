using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GemSpawner : MonoBehaviour
{
    public GemBase Gemtype;
    public GameEventGem GemCollected;

    private GameObject Gem;
    public List<Renderer> GemVariants;
    private int Selected;

    private void Awake()
    {
        Gem = Gemtype.Gem;
        GetGemVariants();
    }

    private void GetGemVariants()
    {
        GemVariants = new List<Renderer>();
        Renderer[] Gems = Gem.GetComponentsInChildren<Renderer>();
        foreach (Renderer Gem in Gems)
        {
            GemVariants.Add(Gem);
        }
        SelectGemType();
    }
    private void SelectGemType()
    {
        switch (Gemtype.Type)
        {
            case GemBase.GemColor.BoxCrate:
                Selected = Convert.ToInt32(Gemtype.Type);
                GemVariants[Selected].enabled = true;
                break;
            case GemBase.GemColor.Hidden:
                Selected = Convert.ToInt32(Gemtype.Type);
                GemVariants[Selected].enabled = true;
                break;
            case GemBase.GemColor.Blue:
                Selected = Convert.ToInt32(Gemtype.Type);
                GemVariants[Selected].enabled = true;
                break;
            case GemBase.GemColor.Green:
                Selected = Convert.ToInt32(Gemtype.Type);
                GemVariants[Selected].enabled = true;
                break;
            case GemBase.GemColor.Orange:
                Selected = Convert.ToInt32(Gemtype.Type);
                GemVariants[Selected].enabled = true;
                break;
            case GemBase.GemColor.Purple:
                Selected = Convert.ToInt32(Gemtype.Type);
                GemVariants[Selected].enabled = true;
                break;
            case GemBase.GemColor.Red:
                Selected = Convert.ToInt32(Gemtype.Type);
                GemVariants[Selected].enabled = true;
                break;
            case GemBase.GemColor.Yellow:
                Selected = Convert.ToInt32(Gemtype.Type);
                GemVariants[Selected].enabled = true;
                break;
        }
    }
    public void CollectGem()
    {
        GemCollected.RaiseGem(Gemtype);
        gameObject.SetActive(false);
    }
}
