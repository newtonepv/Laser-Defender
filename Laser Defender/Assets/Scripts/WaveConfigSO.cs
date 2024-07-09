using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] float delayBetweenEnemiesVariance;
    [SerializeField] float delayBetweenEnemies;
    [SerializeField] float minDelayBetweenEnemies;

    public float GetDelayBetweenEnemies()
    {
        if(delayBetweenEnemiesVariance > delayBetweenEnemies)
        {
            delayBetweenEnemiesVariance = delayBetweenEnemies;
        }
        float delay = Random.Range(delayBetweenEnemies - delayBetweenEnemiesVariance, delayBetweenEnemies + delayBetweenEnemiesVariance);
        if (delay < minDelayBetweenEnemies)
        {
            delay= minDelayBetweenEnemies;
        }
    return delay; 
    }

    public List<GameObject> GetEnemyPrefabList()
    {
        return enemyPrefabs; 
    }

    public GameObject GetEnemyAtIndex(int index)
    {
        return enemyPrefabs[index];
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public float GetMoveSpeed()
    {
    return moveSpeed; 
    }

    public Transform GetFirstWayPoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> wayPointList= new List<Transform>();
        foreach(Transform c in pathPrefab)
        {
            wayPointList.Add(c);
        }
        return wayPointList;
    }
}
