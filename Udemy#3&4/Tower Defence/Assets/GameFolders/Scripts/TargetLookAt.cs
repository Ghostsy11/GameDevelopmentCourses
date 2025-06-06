using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLookAt : MonoBehaviour
{
    [SerializeField] Transform _weapon;
    [SerializeField] ParticleSystem _projectilePartices;
    [SerializeField] float _range = 15f;
    private Transform _target;


    void Update()
    {
        FindClosestTaget();
        AimWeapom();
    }

    private void FindClosestTaget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTaget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {

            float tagetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (tagetDistance < maxDistance)
            {
                closestTaget = enemy.transform;
                maxDistance = tagetDistance;
            }
        }
        _target = closestTaget;
    }

    private void AimWeapom()
    {
        float _tagetDistance = Vector3.Distance(transform.position, _target.transform.position);

        _weapon.LookAt(_target);

        if (_tagetDistance < _range)
        {
            Attcak(true);
        }
        else
        {
            Attcak(false);
        }
    }

    private void Attcak(bool isActive)
    {
        var emissionModule = _projectilePartices.emission;
        emissionModule.enabled = isActive;
    }
}
