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
        Gizmos.color = Color.red;

        for(int i = 0; i < Levels.Count; i++)
        {
            if (Levels[i].GetComponent<Level>().Path == Level.PathType.single && i + 1 < Levels.Count)
            {
                Gizmos.DrawLine(Levels[i].position, Levels[i + 1].position);
            }
        }
    }
}
