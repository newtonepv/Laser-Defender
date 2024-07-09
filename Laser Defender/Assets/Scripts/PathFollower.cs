using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    WaveConfigSO waveConfig;
    EnemySpawner enemySpawner;
    List<Transform> wayPoints;
    int actualFollowingWaypointIndex=0;
    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }
    void Start()
    {
        waveConfig = enemySpawner.GetCurrenWave();
        wayPoints = waveConfig.GetWaypoints();
        transform.position = wayPoints[actualFollowingWaypointIndex].position;
    }
    void FollowPath()
    {
        if (wayPoints.Count > actualFollowingWaypointIndex)
        {
            float spaceVariation = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, wayPoints[actualFollowingWaypointIndex].position, spaceVariation);
            if (transform.position == wayPoints[actualFollowingWaypointIndex].position)
            {
                actualFollowingWaypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Update()
    {
        FollowPath();
    }
}
