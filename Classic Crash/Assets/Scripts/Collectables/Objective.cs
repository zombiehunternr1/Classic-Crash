using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour, IInteractable
{
    public void Interacting(int side)
    {
        if(side <= 8)
            CollectItem();
    }

    public void CollectItem()
    {
        gameObject.SetActive(false);
    }
}
