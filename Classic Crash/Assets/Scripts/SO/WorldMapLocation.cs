using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WorldMapLocation", menuName = "ScriptableObjects/Worldmap/WorldMapLocation")]
public class WorldMapLocation : ScriptableObject
{
    public bool UnlockNextPath;
    public Vector3 WorldMapPosition;
}
