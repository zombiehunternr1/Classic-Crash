using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour, IInteractable
{
    public float ActivatingSpeed;
    public GameObject GhostCrate;
    public List<GameObject> Crates = new List<GameObject>();

    private void Awake()
    {
        foreach(GameObject Crate in Crates)
        {
            Crate.GetComponent<BoxCollider>().enabled = false;
            Crate.GetComponent<Renderer>().enabled = false;
            GameObject Child = Instantiate(GhostCrate, Crate.transform.position, Crate.transform.rotation);
            Child.transform.SetParent(Crate.transform);
        }
    }

    public void Interacting(int Side)
    {
        if(Side <= 2)
            StartCoroutine(ActivateHidden());
        else if(Side >= 7)
            StartCoroutine(ActivateHidden());
    }

    IEnumerator ActivateHidden()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        foreach (GameObject Crate in Crates)
        {
            Crate.GetComponent<BoxCollider>().enabled = true;
            Crate.GetComponentInChildren<Renderer>();
            Crate.transform.GetChild(Crate.transform.childCount - 1).GetComponent<Renderer>().enabled = false;
            Crate.GetComponent<Renderer>().enabled = true;
            yield return new WaitForSeconds(ActivatingSpeed);
        }
    }
}
