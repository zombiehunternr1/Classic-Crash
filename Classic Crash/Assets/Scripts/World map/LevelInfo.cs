using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelInfo : MonoBehaviour
{
    public int Level;
    public BezierCurve PathToUnlock;
    public TextMeshProUGUI LevelNumber;
    public RectTransform GemsPosition;
    public Image Background;

    public enum GemColor { BoxCrate, Hidden, Blue, Green, Orange, Purple, Red, Yellow };
    public List<GemColor> GemTypes;

    public enum Connected { up, down, left, right };
    public List<Connected> MoveOptions;
    public List<BezierCurve> ConnectedPaths;
    
    [HideInInspector]
    public List<Sprite> UnlockedGems;
    [HideInInspector]
    public List<Sprite> LockedGems;

    [HideInInspector]
    public List<Image> GemImages;

    public void Start()
    {
        Image[] FoundGemUIs = GemsPosition.GetComponentsInChildren<Image>();
        foreach(Image Gem in FoundGemUIs)
        {
            GemImages.Add(Gem);
            UnlockedGems.Add(Gem.sprite);
            Gem.enabled = false;
        }
    }

    public void DisplayLevelInfo(ItemsCollected Gems)
    {
        Background.gameObject.SetActive(true);
        LevelNumber.text = Level.ToString();

        DisplayLockedGems();
        DisplayUnlockedGems(Gems);      
    }

    private void DisplayUnlockedGems(ItemsCollected Gems)
    {
        for (int i = 0; i < Gems.GemsCollected.Count; i++)
        {
            if (Gems.GemsCollected[i].Level == Level)
            {
                for (int j = 0; j < GemTypes.Count; j++)
                {
                    if ((int)Gems.GemsCollected[i].Type == (int)GemTypes[j])
                    {
                        foreach (GemColor GemColor in GemTypes)
                        {
                            if (GemTypes[j] == GemColor.BoxCrate)
                            {
                                GemImages[(int)GemColor.BoxCrate].sprite = UnlockedGems[(int)GemColor.BoxCrate];
                                break;
                            }
                            else if (GemTypes[j] == GemColor.Hidden)
                            {
                                GemImages[(int)GemColor.Hidden].sprite = UnlockedGems[(int)GemColor.Hidden];
                                break;
                            }
                            else if (GemTypes[j] == GemColor.Blue)
                            {
                                GemImages[(int)GemColor.Blue].sprite = UnlockedGems[(int)GemColor.Blue];
                                break;
                            }
                            else if (GemTypes[j] == GemColor.Green)
                            {
                                GemImages[(int)GemColor.Green].sprite = UnlockedGems[(int)GemColor.Green];
                                break;
                            }
                            else if (GemTypes[j] == GemColor.Orange)
                            {
                                GemImages[(int)GemColor.Orange].sprite = UnlockedGems[(int)GemColor.Orange];
                                break;
                            }
                            else if (GemTypes[j] == GemColor.Purple)
                            {
                                GemImages[(int)GemColor.Purple].sprite = UnlockedGems[(int)GemColor.Purple];
                                break;
                            }
                            else if (GemTypes[j] == GemColor.Red)
                            {
                                GemImages[(int)GemColor.Red].sprite = UnlockedGems[(int)GemColor.Red];
                                break;
                            }
                            else if (GemTypes[j] == GemColor.Yellow)
                            {
                                GemImages[(int)GemColor.Yellow].sprite = UnlockedGems[(int)GemColor.Yellow];
                                break;
                            }
                        }
                    }
                }

            }
        }
    }

    private void DisplayLockedGems()
    {
        for (int i = 0; i < GemTypes.Count; i++)
        {
            int Color = Convert.ToInt32(GemTypes[i]);

            for (int j = 0; j < LockedGems.Count; j++)
            {
                if (j == Color)
                {
                    GemImages[j].sprite = LockedGems[j];
                    GemImages[j].enabled = true;
                }
            }
        }
    }

    public void HideDisplayInfo()
    {
        foreach(Image Gem in GemImages)
        {
            Gem.enabled = false;
        }
        Background.gameObject.SetActive(false);
    }
}