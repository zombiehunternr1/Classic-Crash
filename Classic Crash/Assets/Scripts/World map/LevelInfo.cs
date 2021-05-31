using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelInfo : MonoBehaviour
{
    public int Level;
    public string LevelName;
    public BezierCurve PathToUnlock;
    public TextMeshProUGUI LevelNameDisplay;
    public RectTransform Gems;
    public RectTransform Display;
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
    [HideInInspector]
    public List<Image> DisplayGemType;

    private int DisplayCount;

    public void Start()
    {
        Image[] FoundGemUIs = Gems.GetComponentsInChildren<Image>();
        Image[] FoundDisplayUI = Display.GetComponentsInChildren<Image>();
        foreach(Image Gem in FoundGemUIs)
        {
            GemImages.Add(Gem);
            UnlockedGems.Add(Gem.sprite);
            Gem.enabled = false;
        }
        foreach(Image Display in FoundDisplayUI)
        {
            DisplayGemType.Add(Display);
        }
    }

    public void DisplayLevelInfo(ItemsCollected Gems)
    {
        Background.gameObject.SetActive(true);
        LevelNameDisplay.text = LevelName;

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
                                DisplayGemType[j].sprite = UnlockedGems[(int)GemColor.BoxCrate];
                                break;
                            }
                            else if (GemTypes[j] == GemColor.Hidden)
                            {
                                DisplayGemType[j].sprite = UnlockedGems[(int)GemColor.Hidden];
                                break;
                            }
                            else if (GemTypes[j] == GemColor.Blue)
                            {
                                DisplayGemType[j].sprite = UnlockedGems[(int)GemColor.Blue];
                                break;
                            }
                            else if (GemTypes[j] == GemColor.Green)
                            {
                                DisplayGemType[j].sprite = UnlockedGems[(int)GemColor.Green];
                                break;
                            }
                            else if (GemTypes[j] == GemColor.Orange)
                            {
                                DisplayGemType[j].sprite = UnlockedGems[(int)GemColor.Orange];
                                break;
                            }
                            else if (GemTypes[j] == GemColor.Purple)
                            {
                                DisplayGemType[j].sprite = UnlockedGems[(int)GemColor.Purple];
                                break;
                            }
                            else if (GemTypes[j] == GemColor.Red)
                            {
                                DisplayGemType[j].sprite = UnlockedGems[(int)GemColor.Red];
                                break;
                            }
                            else if (GemTypes[j] == GemColor.Yellow)
                            {
                                DisplayGemType[j].sprite = UnlockedGems[(int)GemColor.Yellow];
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
            int GemColor = Convert.ToInt32(GemTypes[i]);

            for (int j = 0; j < LockedGems.Count; j++)
            {
                if (j == GemColor)
                {
                    DisplayGemType[DisplayCount].sprite = LockedGems[j];
                    DisplayCount++;
                }
            }
        }
    }

    public void HideDisplayInfo()
    {
        foreach(Image Display in DisplayGemType)
        {
            Display.sprite = null;
        }
        DisplayCount = 0;
        Background.gameObject.SetActive(false);
    }
}