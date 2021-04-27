using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class GemEvent : UnityEvent<Gem> { }

public class GameEventListenerGem : MonoBehaviour
{
    [SerializeField] private GameEventGem _gameEventGem;
    [SerializeField] private GemEvent _responseGem;

    void Start()
    {
        if (_responseGem == null)
        {
            _responseGem = new GemEvent();
        }
    }

    void OnEnable()
    {
        _gameEventGem.RegisterGemEvent(this);
    }

    void OnDisable()
    {
        _gameEventGem.UnregisterGemListener(this);
    }

    public void OnEventGemRaise(Gem value)
    {
        _responseGem.Invoke(value);
    }
}
