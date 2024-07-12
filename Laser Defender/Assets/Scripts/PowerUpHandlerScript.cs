using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpHandlerScript : MonoBehaviour
{
    Health health;
    ShootingScript shootingScript;
    UiScript uiScript;
    Coroutine shootingDelayChange;
    Coroutine shieldExisting;
    [SerializeField] GameObject shieldPrefab;
    private void Awake()
    {
        health = GetComponent<Health>();
        shootingScript = GetComponent<ShootingScript>();
    }
    void Start()
    {
        uiScript =FindObjectOfType<UiScript>();
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
                HandleShootingSpeedUp(powerUp.GetShootingDelay(), powerUp.GetDuration(), powerUp.GetSprite());
            }
            else if (id == 2)
            {
                HandleShield(powerUp.GetDuration(), powerUp.GetSprite());
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
    private void HandleShootingSpeedUp(float newDelay, float time, Sprite powerUpImage)
    {
        if (shootingScript != null)
        {
            if (shootingDelayChange != null)
            {
                StopCoroutine(shootingDelayChange);

                shootingDelayChange = StartCoroutine(ChangeShootingDelay(newDelay, time, powerUpImage));
            }
            else
            {
                shootingDelayChange = StartCoroutine(ChangeShootingDelay(newDelay, time, powerUpImage));
            }
        }
    }
    private IEnumerator ChangeShootingDelay(float newDelay, float time, Sprite powerUpImage)
    {
        float normalDelay = shootingScript.GetShootingDelay();
        shootingScript.UpdateShootingTime(newDelay);

        if (uiScript != null) { 

        uiScript.SetPowerUpImage(powerUpImage);

        }

        yield return new WaitForSeconds(time);

        if (uiScript != null)
        {
            uiScript.SetPowerUpImage(null);
        }
        shootingScript.UpdateShootingTime(normalDelay);
    }
    private void HandleShield(float time, Sprite shieldImage)
    {
        if (shieldExisting != null)
        {
            StopCoroutine(shieldExisting);
            shieldExisting = StartCoroutine(StartShield(time, shieldImage));
        }
        else
        {
            shieldExisting = StartCoroutine(StartShield(time, shieldImage));
        }
    }

    private IEnumerator StartShield(float time, Sprite shieldImage)
    {
        GameObject instance = Instantiate(shieldPrefab,
                               transform.position,
                               Quaternion.identity);

        if (uiScript != null)
        {

            uiScript.SetPowerUpImage(shieldImage);

        }

        yield return new WaitForSeconds(time);
        if (instance.TryGetComponent<ShieldScript>(out ShieldScript script)) { 
        script.ActivateExplosionEffect(transform.position);
        }

        if (uiScript != null)
        {

            uiScript.SetPowerUpImage(null);

        }
        Destroy(instance);
    }

    /*instance = Instantiate(projectiles[actualIndex],
                                           transform.position,
                                           Quaternion.identity
                                           );*/
    void Update()
    {
        
    }

}
