using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform _target;
    NavMeshAgent _navMeshAgent;
    [SerializeField] float _inAttackRange = 5f;
    [SerializeField] float _distanceToTarget = Mathf.Infinity;
    [SerializeField] bool _isProvoked = false;
    Animator AttackState;
    [SerializeField] float _turnSpeed = 5f;
    EnemyHealth enemyHealthTOcheck;
    [SerializeField] float dealDamageToEnemy = 50;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        AttackState = GetComponent<Animator>();
        enemyHealthTOcheck = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        if (enemyHealthTOcheck.EnemyIsDead())
        {
            _navMeshAgent.enabled = false;
            enabled = false;
        }
        else
        {

            SetDestination();
        }
    }
    public void OnDamageTaken()
    {
        _isProvoked = true;
    }
    private void SetDestination()
    {
        _distanceToTarget = Vector3.Distance(_target.position, transform.position);
        if (_distanceToTarget <= _inAttackRange)
        {
            _isProvoked = true;
        }
        if (_isProvoked)
        {

            Attack();
        }
    }

    private void Attack()
    {
        FaceTarget();
        if (_distanceToTarget >= _navMeshAgent.stoppingDistance)
        {
            FollowPlayer();

        }

        if (_distanceToTarget <= _navMeshAgent.stoppingDistance)
        {

            AttackingPlayer();

        }
    }
    private void FollowPlayer()
    {
        AttackState.SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        _navMeshAgent.SetDestination(_target.position);
    }
    private void AttackingPlayer()
    {

        AttackState.SetBool("attack", true);
        Debug.Log("Attacking Player");
        //BroadcastMessage("AttackHitEvent");
        //FindObjectOfType<EnemyAttack>().AttackHitEvent();
        FindObjectOfType<PlayerHealth>().GetPlayerHealth(dealDamageToEnemy);
    }

    private void FaceTarget()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        Quaternion LookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, LookRotation, Time.deltaTime * _turnSpeed);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _inAttackRange);
    }

}
