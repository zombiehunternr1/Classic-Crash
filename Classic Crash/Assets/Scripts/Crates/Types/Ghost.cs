using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private AudioSource ActivatingSFX;

    private void Awake()
    {
        ActivatingSFX = GetComponent<AudioSource>();
    }

    public void PlaySFX()
    {
        ActivatingSFX.Play();
    }
}
