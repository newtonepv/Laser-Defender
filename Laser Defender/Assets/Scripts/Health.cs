using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class Health : MonoBehaviour
{
    float health;
    [SerializeField] float maxHealth = 200f;
    [SerializeField] ParticleSystem expEffect;
    [SerializeField] bool hasCameraControl;
    [SerializeField] bool isPlayer;
    [SerializeField] bool hasLogControl;
    [SerializeField] bool isProjectile;


    [Header("Audio")]
    [SerializeField] AudioClip explosionAudio;
    [Range(0f, 1f)] public float explosionAudioVolume;

    [SerializeField] AudioClip impactAudio;
    [Range(0f, 1f)] public float impactAudioVolume;


    [Header("EnemyOnly")]
    [SerializeField] float onKilledScoreIncrement;

    CameraShake cameraShake;
    AudioPlayerScript playerScript;
    PointsCounter pointsCounter;
    DamageDealing damageDealing;
    UiScript uiScript;
    SceneManagerScript sceneManagerScript;
    private void Awake()
    {
        health=maxHealth;
    }
    void Start()
    {
        playerScript = FindObjectOfType<AudioPlayerScript>();
        cameraShake = Camera.main.GetComponent<CameraShake>();
        uiScript = FindObjectOfType<UiScript>();
        pointsCounter = FindObjectOfType<PointsCounter>();
        sceneManagerScript = FindObjectOfType<SceneManagerScript>();
        PrintHealth();
    }

    float GetHealth()
    {
    return health; 
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        damageDealing = collider.GetComponent<DamageDealing>();

        if (damageDealing != null)
        {


            ActivateExplosionEffect(collider.gameObject.transform.position);

            ActivateCameraShakeOrNot();

            if (!isProjectile)
            {
                playerScript.PlayClip(impactAudio, impactAudioVolume);
            }

            TakeDamage(damageDealing.GetDamage());

            damageDealing.Hit();

        }
    }

    private void ActivateCameraShakeOrNot()
    {
        if (hasCameraControl && cameraShake != null)
        {
            cameraShake.Play();
        }
    }

    private void TakeDamage(float damage)
    {
        SetHealth(health - damage);

        if (health <= 0 && this.gameObject!=null)
        {
            Die();
        }

    }
    private void Die()
    {
        if (pointsCounter != null)
        {
            incrementScore();
        }
        health = 0;

        playerScript.PlayClip(explosionAudio, explosionAudioVolume);

        if (isPlayer) {
        sceneManagerScript.LoadGameOver();
        }
        Destroy(gameObject);
    }
    private void ActivateExplosionEffect(Vector3 location)
    {
        if (expEffect != null)
        {
            ParticleSystem particles = Instantiate(expEffect, location, expEffect.transform.rotation);
            Destroy(particles.gameObject, particles.main.duration + particles.main.startLifetime.constant);
        }
    }

    private void PrintHealth()
    {
        if (hasLogControl && uiScript !=null)
        {
            uiScript.SetHealth(GetHealth()/200);
        }
    }
    public void Heal(float deltaHealth)
    {
        if (health + deltaHealth > maxHealth)
        {
            SetHealth(maxHealth);
        }
        else if (health > 0)
        {
            SetHealth(health + deltaHealth);
        }
    
    }
    void SetHealth(float health)
    {
        this.health = health;
        PrintHealth();
    }
    void incrementScore()
    {
        if (pointsCounter != null && onKilledScoreIncrement!=0)
        {
            pointsCounter.SetScore(pointsCounter.GetScore() + onKilledScoreIncrement);
        }

    }
}
