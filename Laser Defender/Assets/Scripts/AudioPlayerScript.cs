using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioPlayerScript : MonoBehaviour
{
    /*
    [Header("Shooting")]
    [SerializeField] AudioClip shootAudio;
    [Range(0f, 1f)] public float shootAudioVolume;
    [Header("Impact")]
    [SerializeField] AudioClip impactAudio;
    [Range(0f, 1f)] public float impactAudioVolume;
    [Header("Explosion")]
    [SerializeField] AudioClip explosionAudio;
    [Range(0f, 1f)] public float explosionAudioVolume;
    [Header("Projectile Explosion")]
    [SerializeField] AudioClip projectileExplosionAudio;
    [Range(0f, 1f)] public float projectileExplosionVolume;*/
    static AudioPlayerScript instance;
    private void Awake()
    {
        Singleton();
    }
    void Singleton()
    {
        if (instance != null)
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {

    }
    /*public void PlayShootAudio()
    {
        PlayClip(shootAudio,shootAudioVolume);
    }
    public void PlayImpactAudio()
    {
        PlayClip(impactAudio,impactAudioVolume);
    }
    public void PlayExplosionAudio(bool isProjectile)
    {
        if (isProjectile)
        {
            PlayClip(projectileExplosionAudio, projectileExplosionVolume);
        }
        else
        {
            PlayClip(explosionAudio, explosionAudioVolume);
        }
    }*/

    public void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip,
                                        Camera.main.transform.position,
                                        volume);
        }
    }
}
