using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectile;
    [SerializeField] float shootingDelay;
    [SerializeField] float lifeTime;
    [SerializeField] float projSpeed;
    [Header("AI")]
    [SerializeField] bool autoShoot;
    [SerializeField] float shootingDelayVariation;
    [SerializeField] float minimumShootingDelay;
    float shootingTime;
    Coroutine shootingCoroutine;
    AudioPlayerScript playerScript;

    private void Awake()
    {
        if(shootingDelay-shootingDelayVariation < minimumShootingDelay)
        {
            shootingDelayVariation = shootingDelay-minimumShootingDelay ;
        }
        shootingTime = Random.Range(shootingDelay - shootingDelayVariation,
                                    shootingDelay + shootingDelayVariation);
    }
    private void Start()
    {
        playerScript= FindObjectOfType<AudioPlayerScript>();
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
            playerScript.PlayShootAudio();
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
