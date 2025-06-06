using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] EnemySpwaner enemySpwaner;
    [SerializeField] WavesConfigs _wavesConfigs;
    List<Transform> _wayPoints;
    [SerializeField] int waypointIndex = 0;
    // Start is called before the first frame update

    private void Awake()
    {
        enemySpwaner = FindObjectOfType<EnemySpwaner>();
    }
    void Start()
    {
        _wavesConfigs = enemySpwaner.GetCurrentWave();
        _wayPoints = _wavesConfigs.GetWayPoints();
        transform.position = _wayPoints[waypointIndex].position;
    }
    // Update is called once per frame
    void Update()
    {
        FollowPath();
    }
    private void FollowPath()
    {
        if (waypointIndex < _wayPoints.Count)
        {
            Vector3 targetPosition = _wayPoints[waypointIndex].position;
            float delta = _wavesConfigs.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject, 1);
        }
    }
}
