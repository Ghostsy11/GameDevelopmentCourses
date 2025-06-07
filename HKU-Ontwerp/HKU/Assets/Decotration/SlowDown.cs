using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{
    public float _muiltplier;
    PlayerController _controller;
    public ParticleSystem _SLparticleSystem;

    private void Start()
    {
        _SLparticleSystem.Pause();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "SlowDown")
        {
            _controller = FindObjectOfType<PlayerController>();
            _SLparticleSystem.Play();
            _controller.speed -= _muiltplier;
            _controller.maxNumberOfJumps -= 1;
            Destroy(other.gameObject);
        }
    }
}
