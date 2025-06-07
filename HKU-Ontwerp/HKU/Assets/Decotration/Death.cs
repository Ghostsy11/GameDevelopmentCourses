using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public float _muiltplier1;
    PlayerController _controller1;
    public ParticleSystem ParticleSystem_particleSystem;

    private void Start()
    {
        ParticleSystem_particleSystem.Pause();
    }
    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "FlyToDeath")
        {
            Debug.Log("test");
            ParticleSystem_particleSystem.Play();
            _controller1 = FindObjectOfType<PlayerController>();
            _controller1.speed *= -_muiltplier1;
            _controller1.maxNumberOfJumps -= 1;
            Destroy(other.gameObject, 1f);
        }
    }
}
