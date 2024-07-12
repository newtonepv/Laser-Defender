using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    /*
     * 
     ID       NAME
    0         health
    1         temporary shooting speed
    
     */
    [SerializeField] int PowerUpID;
    [SerializeField] float powerUpDuration;
    [SerializeField] Sprite powerUpSprite;
    [Header("For ID 0")]
    [SerializeField] float HealthIncrease;
    
    [Header("For ID 1")]
    [SerializeField] float shootingDelay;



    public int GetPowerUpID()
    {
        return PowerUpID;
    }
    public float GetHealthIncrease()
    {
        return HealthIncrease;
    }

    public float GetShootingDelay()
    {
        return shootingDelay;
    }
    public float GetDuration()
    {
        return powerUpDuration;
    }
    public Sprite GetSprite()
    {
        return powerUpSprite;
    }

}
