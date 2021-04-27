using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gem : MonoBehaviour
{
    public GameEventGem GemCollected;
    public enum GemColor { BoxCrate, Hidden, Blue, Green, Orange, Purple, Red, Yellow}
    public GemColor GemType;
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
        switch (GemType)
        {
            case GemColor.BoxCrate:
                Selected = Convert.ToInt32(GemType);
                GemVariants[Selected].enabled = true;
                break;
            case GemColor.Hidden:
                Selected = Convert.ToInt32(GemType);
                GemVariants[Selected].enabled = true;
                break;
            case GemColor.Blue:
                Selected = Convert.ToInt32(GemType);
                GemVariants[Selected].enabled = true;
                break;
            case GemColor.Green:
                Selected = Convert.ToInt32(GemType);
                GemVariants[Selected].enabled = true;
                break;
            case GemColor.Orange:
                Selected = Convert.ToInt32(GemType);
                GemVariants[Selected].enabled = true;
                break;
            case GemColor.Purple:
                Selected = Convert.ToInt32(GemType);
                GemVariants[Selected].enabled = true;
                break;
            case GemColor.Red:
                Selected = Convert.ToInt32(GemType);
                GemVariants[Selected].enabled = true;
                break;
            case GemColor.Yellow:
                Selected = Convert.ToInt32(GemType);
                GemVariants[Selected].enabled = true;
                break;
        }
    }

    public void CollectGem()
    {
        GemCollected.RaiseGem(this);
    }
}
