using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXCrateTypes : MonoBehaviour
{
    private AudioSource SFXCrateTypeSource;
    private AudioClip SFXCrateBreak;
    private AudioClip SFXCrateBounce;
    private AudioClip SFXTNTCountdown;
    private AudioClip SFXTNTExplode;
    private AudioClip SFXNitroExplode;
    private AudioClip SFXActivator;
    private AudioClip SFXActivatingCrate;
    private AudioClip SFXNitroSmallHop;
    private AudioClip SFXNitroBigHop;
    private AudioClip SFXCheckPoint;

    private void Awake()
    {
        GetSFXCrateTypes();
    }

    private void GetSFXCrateTypes()
    {
        AudioSource[] AudioSources = GetComponents<AudioSource>();
        SFXCrateTypeSource = AudioSources[0];
        SFXCrateBreak = AudioSources[0].clip;
        SFXCrateBounce = AudioSources[1].clip;
        SFXTNTCountdown = AudioSources[2].clip;
        SFXTNTExplode = AudioSources[3].clip;
        SFXNitroExplode = AudioSources[4].clip;
        SFXActivator = AudioSources[5].clip;
        SFXActivatingCrate = AudioSources[6].clip;
        SFXNitroSmallHop = AudioSources[7].clip;
        SFXNitroBigHop = AudioSources[8].clip;
        SFXCheckPoint = AudioSources[9].clip;
    }

    public void PlayCrateBreak()
    {
        SFXCrateTypeSource.PlayOneShot(SFXCrateBreak);
    }

    public void PlayCrateBounce()
    {
        SFXCrateTypeSource.PlayOneShot(SFXCrateBounce);
    }

    public void PlayTNTCountdown()
    {
        SFXCrateTypeSource.PlayOneShot(SFXTNTCountdown);
    }

    public void PlayTNTExplode()
    {
        SFXCrateTypeSource.PlayOneShot(SFXTNTExplode);
    }

    public void PlayNitroExplode()
    {
        SFXCrateTypeSource.PlayOneShot(SFXNitroExplode);
    }

    public void PlayNitroSmalHop()
    {
        SFXCrateTypeSource.PlayOneShot(SFXNitroSmallHop);
    }

    public void PlayNitroBigHop()
    {
        SFXCrateTypeSource.PlayOneShot(SFXNitroBigHop);
    } 

    public void PlayActivator()
    {
        SFXCrateTypeSource.PlayOneShot(SFXActivator);
    }

    public void PlayCrateActivating()
    {
        SFXCrateTypeSource.PlayOneShot(SFXActivatingCrate);
    }

    public void StopTNTCountdown()
    {
        SFXCrateTypeSource.Stop();
    }

    public void PlayCheckPoint()
    {
        SFXCrateTypeSource.PlayOneShot(SFXCheckPoint);
    }
}
