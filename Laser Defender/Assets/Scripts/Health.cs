using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class Health : MonoBehaviour
{
    DamageDealing damageDealing;
    [SerializeField] float health = 100f;
    [SerializeField] ParticleSystem expEffect;
    [SerializeField] bool hasCameraControl;
    CameraShake cameraShake;

    void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(LayerMask.LayerToName(collider.gameObject.layer));
        Debug.Log(LayerMask.LayerToName(this.gameObject.layer));
        damageDealing = collider.GetComponent<DamageDealing>();

        if (damageDealing != null)
        {


            ActivateExplosionEffect(collider.gameObject.transform.position);

            ActivateCameraShakeOrNot();
            
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
        Debug.Log("Damage taken: " + damage);
        health -= damage;
        if (health <= 0 && this.gameObject!=null)
        {
            health = 0;
            Destroy(gameObject);
        }
    }

    private void ActivateExplosionEffect(Vector3 location)
    {
        if (expEffect != null)
        {
            ParticleSystem particles = Instantiate(expEffect, location, expEffect.transform.rotation);
            Destroy(particles.gameObject, particles.main.duration + particles.main.startLifetime.constant);
        }
    }
}
