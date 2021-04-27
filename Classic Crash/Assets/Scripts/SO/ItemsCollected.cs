using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsCollected", menuName = "ScriptableObjects/Items/CollectedItems")]
public class ItemsCollected : ScriptableObject
{
    public List<Gem> GemsCollected;
    public int Wumpa;
    public int Lives;
}
