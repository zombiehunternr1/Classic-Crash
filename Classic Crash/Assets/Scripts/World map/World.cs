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

        for (int i = 0; i < GameManager.Instance.WorldMapLocation.PathsInWorldUnlocked.Count; i++)
        {
            if (GameManager.Instance.WorldMapLocation.PathsInWorldUnlocked[i] == true)
            {
                PathsInWorld[i].Unlocked = true;
            }
        }
        for(int i = 0; i < GameManager.Instance.WorldMapLocation.DecorationPathInWorldUnlocked.Count; i++)
        {
            if (GameManager.Instance.WorldMapLocation.DecorationPathInWorldUnlocked[i] == false)
            {
                PathDecorationsInWorld[i].FirstTime = false;
            }
        }
    }

    private void GetAllWorldPaths()
    {
        if (PathsInWorld.Count == 0)
        {
            BezierCurve[] PathsFound = GetComponentsInChildren<BezierCurve>();
            foreach (BezierCurve Path in PathsFound)
            {
                PathsInWorld.Add(Path);
                if (!GameManager.Instance.WorldMapLocation.PathsInWorldUnlocked.Contains(Path))
                {
                    GameManager.Instance.WorldMapLocation.PathsInWorldUnlocked.Add(Path.Unlocked);
                }
            }
        }
    }

    private void GetAllWorldPathDecorations()
    {
        if (PathDecorationsInWorld.Count == 0)
        {
            BezierPathVisualisation[] DecorationPathsFound = GetComponentsInChildren<BezierPathVisualisation>();
            foreach (BezierPathVisualisation PathDecoration in DecorationPathsFound)
            {
                PathDecorationsInWorld.Add(PathDecoration);
                if (!GameManager.Instance.WorldMapLocation.DecorationPathInWorldUnlocked.Contains(PathDecoration))
                {
                    GameManager.Instance.WorldMapLocation.DecorationPathInWorldUnlocked.Add(PathDecoration);
                }
            }
        }
    }
}


