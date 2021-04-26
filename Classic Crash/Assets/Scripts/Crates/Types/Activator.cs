using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour, IInteractable
{
    public float ActivatingSpeed;
    public GameObject GhostCratePrefab;
    public List<GameObject> Crates = new List<GameObject>();

    [HideInInspector]
    public bool IsActivated;
    private Animator Activation;

    private void Awake()
    {
        Activation = gameObject.GetComponentInChildren<Animator>();
        Setup();
    }

    public void Setup()
    {
        if (Crates != null && Crates.Count != 0)
        {
            IsActivated = false;
            gameObject.GetComponent<Renderer>().enabled = true;
            Activation.SetBool("Active", false);
            GameObject GhostCrate = GhostCratePrefab;
            foreach (GameObject Crate in Crates)
            {
                Crate.GetComponent<BoxCollider>().enabled = false;
                Crate.GetComponent<Renderer>().enabled = false;
                if (Crate.GetComponent<TNT>())
                {
                    TNT TNT = Crate.GetComponent<TNT>();
                    TNT.IsGhost = true;
                    TNT.DisableEmission();
                }
                if (Crate.GetComponent<Nitro>()){
                    Crate.GetComponent<Nitro>().CanBounce = false;
                }

                int LastChild = Crate.transform.childCount;
                if (LastChild > 0)
                {
                    for (int i = 0; i < LastChild; i++)
                    {
                        if (Crate.transform.GetChild(i).gameObject.layer == 6)
                        {
                            Crate.transform.GetChild(Crate.transform.childCount - 1).GetComponent<Renderer>().enabled = true;
                        }
                        else
                        {
                            if(Crate.transform.GetChild(LastChild - 1).gameObject.layer == 6)
                            {
                                Crate.transform.GetChild(Crate.transform.childCount - 1).GetComponent<Renderer>().enabled = true;
                            }
                            else
                            {
                                GameObject Child = Instantiate(GhostCrate, Crate.transform.position, Crate.transform.rotation);
                                Child.transform.SetParent(Crate.transform);
                                return;
                            }
                        }
                    }
                }
                else
                {
                    GameObject Child = Instantiate(GhostCrate, Crate.transform.position, Crate.transform.rotation);
                    Child.transform.SetParent(Crate.transform);
                }
            }
        }
        else
        {
            gameObject.GetComponent<Renderer>().enabled = false;
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
        if (!IsActivated)
        {
            IsActivated = true;
            Activation.SetBool("Active", true);
            foreach (GameObject Crate in Crates)
            {
                if (Crate.GetComponent<TNT>())
                {
                    Crate.GetComponent<TNT>().AnimTNT.SetTrigger("SetInactive");
                }
                Crate.GetComponent<BoxCollider>().enabled = true;
                Crate.GetComponentInChildren<Renderer>();
                Crate.transform.GetChild(Crate.transform.childCount - 1).GetComponent<Renderer>().enabled = false;
                Crate.GetComponent<Renderer>().enabled = true;
                yield return new WaitForSeconds(ActivatingSpeed);
            }
        }      
    }
}
