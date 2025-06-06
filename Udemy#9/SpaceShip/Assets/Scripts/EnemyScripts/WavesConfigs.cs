using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WavesConfigs : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform _pathPrefab;
    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] float timeBetweenEnemySpwans = 1f;
    [SerializeField] float spwanTimeVariance = 0f;
    [SerializeField] float minimumSpwanTime = 0.2f;
    public int GetEnemyCount()
    {

        return enemyPrefabs.Count;
    }
    public Transform GetStartingWayPoint()
    {
        return _pathPrefab.GetChild(0);
    }
    public List<Transform> GetWayPoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in _pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public GameObject GetEnemyPrefabs(int index)
    {
        return enemyPrefabs[index];

    }
    public float GetMoveSpeed()
    {
        return _moveSpeed;
    }
    public float GetRandomSpwanTime()
    {
        float spwanTime = Random.Range(timeBetweenEnemySpwans - spwanTimeVariance, timeBetweenEnemySpwans + spwanTimeVariance);
        return Mathf.Clamp(spwanTime, minimumSpwanTime, float.MaxValue);
    }

}
