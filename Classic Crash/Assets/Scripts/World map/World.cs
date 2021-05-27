using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class World : MonoBehaviour
{
    public List<BezierCurve> PathsInWorld;
    public List<BezierPathVisualisation> PathDecorationsInWorld;

    private void Start()
    {
        GetAllWorldPaths();
        GetAllWorldPathDecorations();
    }

    private void GetAllWorldPaths()
    {
        if (PathsInWorld.Count == 0)
        {
            BezierCurve[] PathsFound = GetComponentsInChildren<BezierCurve>();
            foreach (BezierCurve Path in PathsFound)
            {
                PathsInWorld.Add(Path);             
            }
        }
        CheckAllWorldPaths();
    }

    private void GetAllWorldPathDecorations()
    {
        if (PathDecorationsInWorld.Count == 0)
        {
            BezierPathVisualisation[] DecorationPathsFound = GetComponentsInChildren<BezierPathVisualisation>();
            foreach (BezierPathVisualisation PathDecoration in DecorationPathsFound)
            {
                PathDecorationsInWorld.Add(PathDecoration);             
            }
        }
        CheckAllPathDecorations();
    }

    private void CheckAllWorldPaths()
    {
        if(GameManager.Instance.WorldMapLocation.PathsInWorldUnlocked.Count != 0)
        {
            for(int i = 0; i < GameManager.Instance.WorldMapLocation.PathsInWorldUnlocked.Count; i++)
            {
                PathsInWorld[i].Unlocked = GameManager.Instance.WorldMapLocation.PathsInWorldUnlocked[i];
            }
        }
        else
        {
            for(int i = 0; i < PathsInWorld.Count; i++)
            {
                GameManager.Instance.WorldMapLocation.PathsInWorldUnlocked.Add(PathsInWorld[i]);
                GameManager.Instance.WorldMapLocation.PathsInWorldUnlocked[i] = false;
            }
        }
    }

    private void CheckAllPathDecorations()
    {
        if(GameManager.Instance.WorldMapLocation.DecorationPathsUnlockedFirstTime.Count != 0)
        {
            for(int i = 0; i < GameManager.Instance.WorldMapLocation.DecorationPathsUnlockedFirstTime.Count; i++)
            {
                PathDecorationsInWorld[i].FirstTime = GameManager.Instance.WorldMapLocation.DecorationPathsUnlockedFirstTime[i];
            }
        }
        else
        {
            for(int i = 0; i < PathDecorationsInWorld.Count; i++)
            {
                GameManager.Instance.WorldMapLocation.DecorationPathsUnlockedFirstTime.Add(PathDecorationsInWorld[i]);
            }
        }
    }
}


