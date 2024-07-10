using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootAudio;
    [Range(0f,1f)] public float shootAudioVolume;
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
        if (shootAudio != null) {
            AudioSource.PlayClipAtPoint(shootAudio, Camera.main.transform.position, shootAudioVolume);
        }
    }
    public void PlayImpactAudio()
    {
        if (impactAudio != null)
        {
            AudioSource.PlayClipAtPoint(impactAudio, Camera.main.transform.position, impactAudioVolume);
        }
    }
    public void PlayExplosionAudio()
    {
        if (explosionAudio != null)
        {
            AudioSource.PlayClipAtPoint(explosionAudio, Camera.main.transform.position, explosionAudioVolume);
        }
    }

}
