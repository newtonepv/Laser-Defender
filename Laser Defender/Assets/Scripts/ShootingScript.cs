using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [Header("General")]
    [SerializeField] List<GameObject> projectiles;
    [SerializeField] List<int> pesos;
    [SerializeField] float shootingDelay;
    [SerializeField] float lifeTime;
    [SerializeField] float projSpeed;
    [SerializeField] bool randomShootingOrder;

    [Header("Audio")]
    [SerializeField] AudioClip shootAudio;
    [Range(0f, 1f)] public float shootAudioVolume;


    [Header("AI")]
    [SerializeField] bool autoShoot;
    [SerializeField] float shootingDelayVariation;
    [SerializeField] float minimumShootingDelay;


    int actualIndex = 0;
    int projectileToShootID = 0;
    float shootingTime;
    Coroutine shootingCoroutine;
    AudioPlayerScript playerScript;

    private void Awake()
    {
        UpdateShootingTime(shootingDelay);
    }
    public float GetShootingDelay() { return shootingDelay; }
    public void UpdateShootingTime(float newDelay)
    {
        if (newDelay - shootingDelayVariation < minimumShootingDelay)
        {
            shootingDelayVariation = newDelay - minimumShootingDelay;
        }
        shootingTime = UnityEngine.Random.Range(newDelay - shootingDelayVariation,
                                    newDelay + shootingDelayVariation);
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
            playerScript.PlayClip(shootAudio, shootAudioVolume);
            GameObject instance;
            if (randomShootingOrder)
            {
                instance = Instantiate(EscolherProjComPeso(),
                                                transform.position,
                                                Quaternion.identity
                                                );
            }
            else
            {
                instance = Instantiate(projectiles[actualIndex],
                                                transform.position,
                                                Quaternion.identity
                                                );
                UpdateIndex();
            }
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projSpeed;
            }
            Destroy(instance, lifeTime);
            yield return new WaitForSeconds(shootingTime);
        }
    }

    private void UpdateIndex()
    {
        projectileToShootID++;
        int x=0;
        foreach(int peso in pesos)
        {
            if (projectileToShootID % peso==0)
            {
                actualIndex = x;
                if(peso == pesos[pesos.Count - 1])
                {
                    projectileToShootID = 0;
                }
            }
            x++;
        }
    }

    private GameObject EscolherProjComPeso()
    {

        int somaPesos = 0;
        for (int i = 0; i < pesos.Count; i++)
        {
            somaPesos += pesos[i];
        }

        System.Random random = new System.Random();
        int numeroAleatorio = random.Next(somaPesos);

        int somaAcumulada = 0;
        for (int i = 0; i < pesos.Count; i++)
        {
            somaAcumulada += pesos[i];
            if (numeroAleatorio < somaAcumulada)
            {
                return projectiles[i];
            }
        }

        // Se por alguma razão nenhum caso for selecionado, retorne o último (deveria ser impossível)
        return projectiles[projectiles.Count - 1];
    }
}
