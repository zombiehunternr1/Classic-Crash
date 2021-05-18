using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICrateBase
{
    bool IsBonus { get; set;} 
    void Break(int Side);

    void DisableCrate();
}