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
    [Header("For ID 0")]
    [SerializeField] float HealthIncrease;
    
    [Header("For ID 1")]
    [SerializeField] float shootingDelay;
    [SerializeField] float shootingDelayDuration;


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
        return shootingDelayDuration;
    }

}
