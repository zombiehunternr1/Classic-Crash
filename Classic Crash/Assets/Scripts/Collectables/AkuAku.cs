using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkuAku : MonoBehaviour, IInteractable
{
    public GameEvent AddAkuAku;
    public void Interacting(int side)
    {
        if(side <= 6)
            CollectItem();
        if(side >= 7)
            DestroyItem();
    }

    private void CollectItem()
    {
        AddAkuAku.Raise();
        DestroyItem();
    }

    private void DestroyItem()
    {
        Destroy(gameObject);
    }
}
