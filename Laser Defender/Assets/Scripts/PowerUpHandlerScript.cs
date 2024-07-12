using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpHandlerScript : MonoBehaviour
{
    Health health;
    ShootingScript shootingScript;
    private void Awake()
    {
        health = GetComponent<Health>();
        shootingScript = GetComponent<ShootingScript>();
    }
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PowerUpScript>(out PowerUpScript powerUp))
        {
            int id = powerUp.GetPowerUpID();
            if (id == 0)
            {
                HandleHealthUp(powerUp.GetHealthIncrease());
            }
            else if (id == 1)
            {
                HandleShootingSpeedUp(powerUp.GetShootingDelay(), powerUp.GetDuration());
            }
            Destroy(collision.gameObject);
        }
    }

    private void HandleHealthUp(float deltaHealth)
    {
        if (health != null)
        {
            health.Heal(deltaHealth);
        }
    }
    private void HandleShootingSpeedUp(float shootingDelay, float shootingDelayDuration)
    {
        if (shootingScript != null)
        {
            shootingScript.TemporarelySetShootingDelay(shootingDelay, shootingDelayDuration);
        }
    }
    void Update()
    {
        
    }

}
