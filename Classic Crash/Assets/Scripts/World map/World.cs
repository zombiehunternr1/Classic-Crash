using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public List<Transform> Routes = new List<Transform>();

    private void OnEnable()
    {
        Transform[] RoutsFound = GetComponentsInChildren<Transform>();
        foreach(Transform Route in RoutsFound)
        {
            if (Route.GetComponent<Route>())
            {
                Routes.Add(Route);
            }
        }
    }
}
