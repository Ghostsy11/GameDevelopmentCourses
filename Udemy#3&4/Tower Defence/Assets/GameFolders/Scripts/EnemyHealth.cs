using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{

    [SerializeField][Range(0, 10)] int maxHitPoints = 5;
    [Tooltip("Add amount to maxHitPoints when enemy dies")]
    [SerializeField] int difficultyRamp = 1;
    [SerializeField] private int currentHitPoints = 0;
    Enemy enemy;
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }
    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHitPoints--;
        Debug.Log(currentHitPoints);
        if (currentHitPoints <= 0)
        {
            enemy.RewardGold();
            maxHitPoints += difficultyRamp;
            gameObject.SetActive(false);

        }
    }
}
