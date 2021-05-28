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

    public List<Sprite> LockedGemImages;

    [HideInInspector]
    public List<Image> GemImages;

    public void Start()
    {
        Image[] FoundGemUIs = GemsPosition.GetComponentsInChildren<Image>();
        foreach(Image Gem in FoundGemUIs)
        {
            GemImages.Add(Gem);
            Gem.enabled = false;
        }
    }

    public void DisplayLevelInfo(ItemsCollected Gems)
    {
        Background.gameObject.SetActive(true);
        LevelNumber.text = Level.ToString();
        for (int i = 0; i < Gems.GemsCollected.Count; i++)
        {
            if (Gems.GemsCollected[i].Level == Level)
            {
                for (int j = 0; j < GemTypes.Count; j++)
                {
                    if ((int)Gems.GemsCollected[i].Type == (int)GemTypes[j])
                    {
                        foreach(GemColor GemColor in GemTypes)
                        {
                            if(GemTypes[j] == GemColor.BoxCrate)
                            {
                                GemImages[(int)GemColor.BoxCrate].enabled = true;
                                break;
                            }
                            else if (GemTypes[j] == GemColor.Hidden)
                            {
                                GemImages[(int)GemColor.Hidden].enabled = true;
                                break;
                            }
                            else if (GemTypes[j] == GemColor.Blue)
                            {
                                GemImages[(int)GemColor.Blue].enabled = true;
                                break;
                            }
                            else if (GemTypes[j] == GemColor.Green)
                            {
                                GemImages[(int)GemColor.Green].enabled = true;
                                break;
                            }
                            else if(GemTypes[j] == GemColor.Orange)
                            {
                                GemImages[(int)GemColor.Orange].enabled = true;
                                break;
                            }
                            else if (GemTypes[j] == GemColor.Purple)
                            {
                                GemImages[(int)GemColor.Purple].enabled = true;
                                break;
                            }
                            else if (GemTypes[j] == GemColor.Red)
                            {
                                GemImages[(int)GemColor.Red].enabled = true;
                                break;
                            }
                            else if (GemTypes[j] == GemColor.Yellow)
                            {
                                GemImages[(int)GemColor.Yellow].enabled = true;
                                break;
                            }
                        }
                    }
                }

            }
        }
    }

    public void HideDisplayInfo()
    {
        Background.gameObject.SetActive(false);
    }
}