using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour, IInteractable
{
    [HideInInspector]
    public Vector3 OriginalPosition;
    private GemSpawner GemObject;
    private Animator Anim;
    private void Awake()
    {
        Physics.IgnoreLayerCollision(6, 7);
        OriginalPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
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
