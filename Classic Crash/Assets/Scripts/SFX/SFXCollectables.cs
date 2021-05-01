using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXCollectables : MonoBehaviour
{
    private AudioSource SFXCollectableSource;
    private AudioClip SFXWumpaAdd;
    private AudioClip SFXLifeAdd;
    private AudioClip SFXGemCollected;
    private AudioClip SFXSpinAway;

    private void Awake()
    {
        GetSFXCollectable();
    }

    private void GetSFXCollectable()
    {
        AudioSource[] AudioSources = GetComponents<AudioSource>();
        SFXCollectableSource = AudioSources[0];
        SFXWumpaAdd = AudioSources[0].clip;
        SFXLifeAdd = AudioSources[1].clip;
        SFXGemCollected = AudioSources[2].clip;
        SFXSpinAway = AudioSources[3].clip;
    }

    public void PlayWumpaAdd()
    {
        SFXCollectableSource.PlayOneShot(SFXWumpaAdd);
    }

    public void PlayLifeAdd()
    {
        SFXCollectableSource.PlayOneShot(SFXLifeAdd);
    }

    public void PlayGemCollected()
    {
        SFXCollectableSource.PlayOneShot(SFXGemCollected);
    }

    public void PlaySpinAway()
    {
        SFXCollectableSource.PlayOneShot(SFXSpinAway);
    }
}
