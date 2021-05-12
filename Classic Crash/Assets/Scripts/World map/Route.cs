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
}
