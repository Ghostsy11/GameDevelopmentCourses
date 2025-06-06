using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] GameObject DeathVFXAndSFX;
    [SerializeField] GameObject GroupOfClonesToDelete;
    [SerializeField] int _PointsToAddToTheScoreBoard;
    [SerializeField] int _EnemyHealthPoint;
    [SerializeField] ParticleSystem OnParticleHit;

    ScoreBoard scoreBoard;


    private void Start()
    {

        scoreBoard = FindObjectOfType<ScoreBoard>();
        GroupOfClonesToDelete = GameObject.FindWithTag("SpwanAtRunTime");
    }
    private void OnParticleCollision(GameObject other)
    {
        EnemyHealth();


        //Destroy(deathVFX, 4f);
    }

    private void InstantiatingVEX()
    {
        GameObject deathVFX = Instantiate(DeathVFXAndSFX, transform.position, Quaternion.identity);
        deathVFX.transform.parent = GroupOfClonesToDelete.transform;
        Destroy(gameObject);
    }

    private void ScoreAddUpOnHit()
    {
        scoreBoard.ScoreAddUp(_PointsToAddToTheScoreBoard);
    }

    private void EnemyHealth()
    {
        if (_EnemyHealthPoint >= 0)
        {
            _EnemyHealthPoint--;
            Debug.Log(_EnemyHealthPoint);
            OnParticleHit.Play();

        }
        else if (_EnemyHealthPoint <= 0)
        {

            ScoreAddUpOnHit();
            InstantiatingVEX();
        }
    }

}
