using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waves;
    [SerializeField] float delayBetweenWaves;
    WaveConfigSO currentWave;
    [SerializeField] bool isLooping;
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        do {  
        foreach (WaveConfigSO c in waves)
        {
            currentWave = c;
            StartCoroutine(SpawnEnemies());
            yield return new WaitForSeconds(delayBetweenWaves);
        }
        } while (isLooping);
    }

    IEnumerator SpawnEnemies()
    {
            for (int i = 0; i < currentWave.GetEnemyCount(); i++)
            {
                Instantiate(currentWave.GetEnemyAtIndex(i),
                            currentWave.GetFirstWayPoint().position,
                            Quaternion.identity,
                            transform);

                yield return new WaitForSeconds(currentWave.GetDelayBetweenEnemies());
            }
        
    }

    public WaveConfigSO GetCurrenWave()
    {
        return currentWave;
    }

    void Update()
    {

    }
}
