using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInAir : MonoBehaviour
{

    [SerializeField] private float timer = 5;
    public GameObject enemyBullet_;

    private float bullettime_;
    public Transform spwan_Point_;

    public float enemySpeed_;


    public float timeToDestroyBullet_;


    [SerializeField] private GameObject FollowInAir_Player;
    private Transform hunt;
    private UIController PlusSCore;
    public ParticleSystem PlayDeath;

    // Start is called before the first frame update
    void Start()
    {

        PlayDeath.Pause();



    }
    private void FixedUpdate()
    {
        _ShootPlayer();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, FollowInAir_Player.transform.position, 5 * Time.deltaTime);

    }


    private void _ShootPlayer()
    {
        bullettime_ -= Time.deltaTime;
        if (bullettime_ > 0) return;
        bullettime_ = timer;
        GameObject bulletObj = Instantiate(enemyBullet_, spwan_Point_.transform.position, spwan_Point_.transform.rotation) as GameObject;


        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * enemySpeed_);
        Destroy(bulletRig, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayDeath.Play();
            PlusSCore = FindObjectOfType<UIController>();
            UIController.scoreCount += 5;
            Destroy(gameObject, 0.5f);
        }
    }

}
