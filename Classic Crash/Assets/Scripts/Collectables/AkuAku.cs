using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkuAku : MonoBehaviour, IInteractable
{
    public void Interacting(int side)
    {
        if(side <= 7)
            CollectItem();
        if(side == 8)
            DestoryItem();
    }

    private void CollectItem()
    {
        gameObject.SetActive(false);
    }

    private void DestoryItem()
    {
        Destroy(gameObject);
    }
}
