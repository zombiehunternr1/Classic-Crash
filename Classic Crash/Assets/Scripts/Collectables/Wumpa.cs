using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wumpa : MonoBehaviour, IInteractable
{
    public GameEventInt AddWumpa;
    private int amount = 1;
    public void Interacting(int Side)
    {
        if (Side >= 1 && Side <= 6 || Side >= 8 && Side <= 9)
            CollectItem();
        else if (Side == 7 || Side >= 10)
            GameManager.Instance.SFXSpinAway();
            DestroyItem();
    }

    private void CollectItem()
    {
        AddWumpa.RaiseInt(amount);
        DestroyItem();
    }

    private void DestroyItem()
    {
        Destroy(gameObject);
    }
}
