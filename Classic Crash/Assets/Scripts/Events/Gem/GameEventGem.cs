using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "ScriptableObjects/GameEvents/GameEventGem")]
public class GameEventGem : ScriptableObject
{
    private List<GameEventListenerGem> _Gemlisteners = new List<GameEventListenerGem>();

    public void RaiseGem(Gem value)
    {
        for (int i = _Gemlisteners.Count - 1; i >= 0; i--)
        {
            _Gemlisteners[i].OnEventGemRaise(value);
        }
    }

    public void RegisterGemEvent(GameEventListenerGem newGemListener)
    {
        _Gemlisteners.Add(newGemListener);
    }

    public void UnregisterGemListener(GameEventListenerGem ListenerGemRemove)
    {
        _Gemlisteners.Remove(ListenerGemRemove);
    }
}