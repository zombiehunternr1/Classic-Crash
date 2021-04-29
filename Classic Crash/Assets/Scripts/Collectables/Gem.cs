using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour, IInteractable
{
    private GemSpawner GemObject;
    private Animator Anim;
    private void Awake()
    {
        GemObject = GetComponent<GemSpawner>();
        Anim = GetComponent<Animator>();
        if(GemObject.Gemtype.Type != GemBase.GemColor.BoxCrate)
        {
            Anim.SetTrigger("Spawn");
        }
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
