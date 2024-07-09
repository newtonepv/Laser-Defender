using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float shootingFrequency;
    [SerializeField] float lifeTime;
    float shootingTime;
    Coroutine shootingCoroutine;

    private void Awake()
    {
        shootingTime = 1 / shootingFrequency;
    }

    public void StartShooting()
    {
        if (shootingCoroutine == null)
        {
            shootingCoroutine = StartCoroutine(ShootingRoutine());
        }
    }

    public void StopShooting()
    {
        if (shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
            shootingCoroutine = null;
        }
    }

    private IEnumerator ShootingRoutine()
    {
        while (true)
        {
            Debug.Log("Shooting");
            GameObject instance =Instantiate(projectile,
                                            transform.position,
                                            Quaternion.identity
                                            );
            Destroy(instance, lifeTime);
            yield return new WaitForSeconds(shootingTime);
        }
    }
}
