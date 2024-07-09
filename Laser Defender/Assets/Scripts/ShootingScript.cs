using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float shootingFrequency;
    [SerializeField] float lifeTime;
    [SerializeField] bool autoShoot;
    [SerializeField] float projSpeed;
    float shootingTime;
    Coroutine shootingCoroutine;

    private void Awake()
    {
        shootingTime = 1 / shootingFrequency;
    }
    private void Start()
    {
        if (autoShoot && shootingCoroutine == null)
        {
            shootingCoroutine = StartCoroutine(ShootingRoutine());
        }
    }
    private void OnDestroy()
    {
        StopShooting();
    }
    public void StartShooting()
    {
        if (autoShoot)
        {
            return;
        }
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
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projSpeed;
            }
            Destroy(instance, lifeTime);
            yield return new WaitForSeconds(shootingTime);
        }
    }
}
