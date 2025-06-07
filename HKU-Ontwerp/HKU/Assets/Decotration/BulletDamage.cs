using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public ParticleSystem _particle;
    private HealtH _healtH;
    private void Start()
    {
        _particle.Pause();
    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            _particle.Play();
            UIController.scoreCount -= 1;
            _healtH = FindObjectOfType<HealtH>();
            _healtH.TakeDamageOnPlayer(20);
            Destroy(other.gameObject, 1);
        }
    }
}
