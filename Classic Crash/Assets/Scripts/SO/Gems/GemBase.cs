using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gem", menuName ="ScriptableObjects/Items/Gem")]
public class GemBase : ScriptableObject
{
    public GameObject Gem;
    public enum GemColor { BoxCrate, Hidden, Blue, Green, Orange, Purple, Red, Yellow }
    public GemColor Type;
}
