using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwaner : MonoBehaviour
{
    [SerializeField] List<WavesConfigs> wavesConfigs;
    [SerializeField] float _TimebetweenWave = 0f;
    [SerializeField] WavesConfigs currentWave;
    [SerializeField] bool _isLooping;
    [SerializeField] float timeBetweenEnemySpwans = 1f;
    [SerializeField] float spwanTimeVariance = 0f;
    [SerializeField] float minimumSpwanTime = 0.2f;
    void Start()
    {
        StartCoroutine(SpwanEnemiesWaves());
    }

    public WavesConfigs GetCurrentWave() { return currentWave; }

    IEnumerator SpwanEnemiesWaves()
    {
        do
        {
            foreach (WavesConfigs wave in wavesConfigs)
            {
                currentWave = wave;

                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {

                    Instantiate(currentWave.GetEnemyPrefabs(i), currentWave.GetStartingWayPoint().position, Quaternion.Euler(0, 0, 180), transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpwanTime());
                }
            }
            yield return new WaitForSeconds(_TimebetweenWave);
        }
        while (_isLooping);
    }
}
