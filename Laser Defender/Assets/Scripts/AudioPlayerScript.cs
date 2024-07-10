using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerScript : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootAudio;
    [Range(0f, 1f)] public float shootAudioVolume;
    [Header("Impact")]
    [SerializeField] AudioClip impactAudio;
    [Range(0f, 1f)] public float impactAudioVolume;
    [Header("Explosion")]
    [SerializeField] AudioClip explosionAudio;
    [Range(0f, 1f)] public float explosionAudioVolume;
    void Start()
    {

    }
    public void PlayShootAudio()
    {
        PlayClip(shootAudio,shootAudioVolume);
    }
    public void PlayImpactAudio()
    {
        PlayClip(impactAudio,impactAudioVolume);
    }
    public void PlayExplosionAudio()
    {
        PlayClip(explosionAudio, explosionAudioVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip,
                                        Camera.main.transform.position,
                                        volume);
        }
    }
}
