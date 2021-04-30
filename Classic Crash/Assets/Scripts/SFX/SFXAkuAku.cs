using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXAkuAku : MonoBehaviour
{
    private AudioSource SFXAkuAkuSource;
    private AudioClip SFXAkaAkuAdd;
    private AudioClip SFXAkuAkuWithdraw;
    private AudioClip SFXInvinsibility;
    private void Awake()
    {
        GetSFXAkuAku();
    }
    private void GetSFXAkuAku()
    {
        AudioSource[] AudioSources = GetComponents<AudioSource>();
        SFXAkuAkuSource = AudioSources[0];
        SFXAkaAkuAdd = AudioSources[0].clip;
        SFXAkuAkuWithdraw = AudioSources[1].clip;
        SFXInvinsibility = AudioSources[2].clip;
    }

    public void PlayAddSFX()
    {
        SFXAkuAkuSource.PlayOneShot(SFXAkaAkuAdd);
    }

    public void PlayWithdrawSFX()
    {
        SFXAkuAkuSource.PlayOneShot(SFXAkuAkuWithdraw);
    }

    public void PlayInvinsibilitySFX()
    {
        SFXAkuAkuSource.PlayOneShot(SFXInvinsibility);
    }

    public void StopInvinsibilitySFX()
    {
        SFXAkuAkuSource.Stop();
    }
}
