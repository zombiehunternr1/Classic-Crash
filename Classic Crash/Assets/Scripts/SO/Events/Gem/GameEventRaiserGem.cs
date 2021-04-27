using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventRaiserGem : MonoBehaviour
{
    [SerializeField] GameEventGem _gameEventGem;

    public void RaiseGemEvent(Gem value)
    {
        _gameEventGem.RaiseGem(value);
    }
}
