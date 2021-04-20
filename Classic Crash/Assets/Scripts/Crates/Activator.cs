using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour, IInteractable
{
    public float ActivatingSpeed;
    public List<GameObject> Crates = new List<GameObject>();

    private void Awake()
    {
        foreach(GameObject crate in Crates)
        {
            crate.GetComponent<BoxCollider>().enabled = false;
            crate.GetComponent<Renderer>().enabled = false;
        }
    }

    public void Interacting(int Side)
    {
        if(Side <= 2)
            StartCoroutine(DisplayHidden());
        else if(Side >= 7)
            StartCoroutine(DisplayHidden());
    }

    IEnumerator DisplayHidden()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        foreach (GameObject crate in Crates)
        {
            crate.GetComponent<BoxCollider>().enabled = true;
            crate.GetComponent<Renderer>().enabled = true;
            yield return new WaitForSeconds(ActivatingSpeed);
        }
    }
}
