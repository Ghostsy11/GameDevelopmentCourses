using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;


public class EnemyManager : MonoBehaviour
{
    public ParticleSystem particle;
    private UIController CONTROLLER;
    [SerializeField] private float timer = 5;
    private float bullettime;
    public NavMeshAgent enemy;
    public Transform _Player;

    public GameObject enemyBullet;
    public Transform spwan_Point;
    public float enemySpeed;
    public float timeToDestroyBullet;

    private void Start()
    {
        particle.Pause();
    }
    private void Update()
    {
        enemy.SetDestination(_Player.position);
        ShootPlayer();
    }

    private void ShootPlayer()
    {
        bullettime -= Time.deltaTime;
        if (bullettime > 0) return;
        bullettime = timer;
        GameObject bulletObj = Instantiate(enemyBullet, spwan_Point.transform.position, spwan_Point.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * enemySpeed);
        Destroy(bulletRig, timeToDestroyBullet);
    }

    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {

            CONTROLLER = FindObjectOfType<UIController>();
            particle.Play();
            UIController.scoreCount += 1;
            Destroy(gameObject, 0.5f);

        }

    }

}
