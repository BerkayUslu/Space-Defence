using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    //config param
    WaveConfig waveConfig;
    List<Transform> waypoints;

    //
    float distanceToGoAtEachFrame;
    private Vector2 target;
    int waypointTargetIndex = 0;
    int waypointCount;


    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        waypointCount = waypoints.Count;
        transform.position = waypoints[waypointTargetIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToGoAtEachFrame = waveConfig.GetMoveSpeedOfEnemies() * Time.deltaTime;

        UpdateTarget();
        Move();
    }

    private void UpdateTarget()
    {
        if (transform.position == waypoints[waypointTargetIndex].position)
        {
            waypointTargetIndex++;
        }
        DestroyIfRoadEnded();
        if (waypointTargetIndex < waypointCount) {
            target = waypoints[waypointTargetIndex].position;
        }
    }

    private void DestroyIfRoadEnded()
    {
        if (waypointTargetIndex >= waypointCount)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, distanceToGoAtEachFrame);
    }

         
    public void SetWaveConfig(WaveConfig wave)
    {
        this.waveConfig = wave;
    }
}
