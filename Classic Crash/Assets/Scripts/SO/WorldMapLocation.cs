using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WorldMapLocation", menuName = "ScriptableObjects/Worldmap/WorldMapLocation")]
public class WorldMapLocation : ScriptableObject
{
    public int PathToUnlock;
    public List<bool> PathsInWorldUnlocked;
    public Vector3 WorldMapPosition;
}
