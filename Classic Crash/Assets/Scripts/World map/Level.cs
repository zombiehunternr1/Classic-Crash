using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public enum PathType { single, split};
    public PathType Path;
    public int level;
    public List<Route> SplitRoute;

    private void OnEnable()
    {
        switch (Path)
        {
            case PathType.single:
                if (level - 1 > -1)
                {
                    //Debug.Log(gameObject.name);
                    //Debug.Log("Yes");
                }
                if(level + 1 < GetComponentInParent<Route>().Levels.Count)
                {
                    //Debug.Log(gameObject.name);
                    //Debug.Log("No");
                }
                if(level - 1 < GetComponentInParent<Route>().Levels.Count)
                {
                    //Debug.Log(gameObject.name);
                    //Debug.Log("No");
                }
            break;
            case PathType.split:
                foreach(Route Route in SplitRoute)
                {
                    //Debug.Log(Route.name);
                }
            break;
        }
    }
}