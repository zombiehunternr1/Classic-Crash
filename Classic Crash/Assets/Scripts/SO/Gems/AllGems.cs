using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AllGems", menuName = "ScriptableObjects/Items/AllGems")]
public class AllGems : ScriptableObject
{
    public List<GemBase> TotalGemsAvailable;
}
