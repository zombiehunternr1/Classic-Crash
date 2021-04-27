using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gemsystem : MonoBehaviour
{
   public GameObject PrefabGem;

   public void SpawnGem(Transform location)
    {
        if (location.gameObject.GetComponent<TotalCrates>())
        {
            var TotalCrates = location.gameObject.GetComponent<TotalCrates>();
            Instantiate(PrefabGem, location.position, transform.rotation);
            TotalCrates.gameObject.SetActive(false);
        }
   }
}
