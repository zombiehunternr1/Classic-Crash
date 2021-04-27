using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour, IInteractable
{
    private GemSpawner GemObject;
    private void Awake()
    {
        GemObject = GetComponent<GemSpawner>();
    }

    public void Interacting(int side)
    {
        if(side <= 8)
            CollectItem();
    }

    public void CollectItem()
    {
        if (GemObject != null)
        {
            GemObject.CollectGem();
        }
    }
}
