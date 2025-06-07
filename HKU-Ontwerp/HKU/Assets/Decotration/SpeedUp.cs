using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public float muiltplier;
    PlayerController controller;
    public ParticleSystem Sparticle;
    private void Start()
    {
        Sparticle.Pause();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "SpeedUp")
        {
            Debug.Log("Speeded");

            Sparticle.Play();
            controller = FindObjectOfType<PlayerController>();
            controller.speed *= muiltplier;
            controller.maxNumberOfJumps += 1;
            Destroy(other.gameObject);
        }
    }
}
