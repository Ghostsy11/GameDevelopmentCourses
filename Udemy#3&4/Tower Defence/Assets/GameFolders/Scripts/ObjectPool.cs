using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField][Range(0.1f, 30)] float _coolDownTimeOfInstantiating = 1f;
    [SerializeField][Range(0, 50)] int _poolSize = 5;
    [SerializeField] GameObject _mainEnemy;

    GameObject[] _pool;

    private void Awake()
    {
        PoplatePool();
    }

    private void PoplatePool()
    {
        _pool = new GameObject[_poolSize];
        for (int i = 0; i < _pool.Length; i++)
        {
            _pool[i] = Instantiate(_mainEnemy, transform);
            _pool[i].SetActive(false);
        }
    }

    private void Start()
    {
        StartCoroutine(ProcessOfInstantiatingEnemies());
    }
    private void EnableObjectInPool()
    {
        for (int i = 0; i < _pool.Length; i++)
        {
            if (_pool[i].activeInHierarchy == false)
            {
                _pool[i].SetActive(true);
                return;
            }
        }
    }
    IEnumerator ProcessOfInstantiatingEnemies()
    {
        while (true)
        {

            EnableObjectInPool();
            yield return new WaitForSeconds(_coolDownTimeOfInstantiating);
        }
    }


}
