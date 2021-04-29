using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsCollected", menuName = "ScriptableObjects/Items/CollectedItems")]
public class ItemsCollected : ScriptableObject
{
    public List<GemBase> GemsCollected;
    public int Wumpa;
    public int Lives;
    public int AkuAkus;
}
