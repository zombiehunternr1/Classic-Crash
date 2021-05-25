using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class World : MonoBehaviour
{
    public List<BezierCurve> PathsInWorld;

    private void Start()
    {
        if(PathsInWorld.Count == 0)
        {
            BezierCurve[] PathsFound = GetComponentsInChildren<BezierCurve>();
            foreach(BezierCurve Path in PathsFound)
            {
                PathsInWorld.Add(Path);
                if (!GameManager.Instance.WorldMapLocation.PathsInWorldUnlocked.Contains(Path))
                {
                    GameManager.Instance.WorldMapLocation.PathsInWorldUnlocked.Add(Path.Unlocked);
                }
            }
        }

        for(int i = 0; i < GameManager.Instance.WorldMapLocation.PathsInWorldUnlocked.Count; i++)
        {
            if (GameManager.Instance.WorldMapLocation.PathsInWorldUnlocked[i] == true)
            {
                PathsInWorld[i].Unlocked = true;
            }
        }
    }
}
