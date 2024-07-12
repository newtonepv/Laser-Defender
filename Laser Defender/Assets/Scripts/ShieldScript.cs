using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    PlayerMovement player;
    [SerializeField] ParticleSystem explosionEffect;
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();   
    }

    void Update()
    {
        transform.position = player.transform.position;
    }
    private void OnDestroy()
    {
    }
    public void ActivateExplosionEffect(Vector3 location)
    {
        if (explosionEffect != null)
        {
            ParticleSystem particles = Instantiate(explosionEffect, location, explosionEffect.transform.rotation);
            Destroy(particles.gameObject, particles.main.duration + particles.main.startLifetime.constant);
        }
    }
}
