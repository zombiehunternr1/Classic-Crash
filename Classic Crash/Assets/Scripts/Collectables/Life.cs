using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour, IInteractable
{
    public GameEvent LifeCollected;

    public void Interacting(int Side)
    {
        if (Side >= 1 && Side <= 6 || Side >= 8 && Side <= 9)
            CollectItem();
        else if (Side == 7 || Side >= 10)
            DestroyItem();
    }

    private void CollectItem()
    {
        LifeCollected.Raise();
        DestroyItem();
    }

    private void DestroyItem()
    {
        Destroy(gameObject);
    }
}
