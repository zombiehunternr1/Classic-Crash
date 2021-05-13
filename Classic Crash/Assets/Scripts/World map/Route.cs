using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    public List<Transform> Levels = new List<Transform>();

    private void OnEnable()
    {
        Transform[] LevelsFound = GetComponentsInChildren<Transform>();
        foreach(Transform Level in LevelsFound)
        {
            if (Level.GetComponent<Level>())
            {
                Levels.Add(Level);
            }
        }
    }

    private void OnDrawGizmos()
    {
        for(int i = 0; i < Levels.Count; i++)
        {
            if (Levels[i].GetComponent<Level>().Path == Level.PathType.single && i + 1 < Levels.Count)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(Levels[i].position, Levels[i + 1].position);
            }
            if(Levels[i].GetComponent<Level>().Path == Level.PathType.split)
            {
                Gizmos.color = Color.green;
                Level SplitLevel = Levels[i].GetComponent<Level>();
                for(int j = 0; j < SplitLevel.SplitRoute.Count; j++)
                {
                    Gizmos.DrawLine(Levels[i].position, SplitLevel.SplitRoute[j].gameObject.transform.position);
                }
            }
        }
    }
}
