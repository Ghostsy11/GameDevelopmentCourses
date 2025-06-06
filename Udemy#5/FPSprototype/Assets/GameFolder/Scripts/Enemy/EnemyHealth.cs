using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float _enemyHealth = 100f;
    [SerializeField] bool _zombieIsDead = false;

    public bool EnemyIsDead()
    {
        return _zombieIsDead;
    }
    public void TakeDamage(float _EnemyHealth)
    {

        BroadcastMessage("OnDamageTaken");
        _enemyHealth -= _EnemyHealth;


        if (_enemyHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (_zombieIsDead) { return; }
        _zombieIsDead = true;
        GetComponent<Animator>().SetTrigger("Dying");

        Destroy(gameObject, 8);
    }
}
