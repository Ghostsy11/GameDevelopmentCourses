using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnTouch : MonoBehaviour
{
    public ParticleSystem _particle_;
    private HealtH _healtH_;
    private void Start()
    {
        _particle_.Pause();
    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeathFloor")
        {
            _particle_.Play();
            UIController.scoreCount -= 1;
            _healtH_ = FindObjectOfType<HealtH>();
            _healtH_.TakeDamageOnPlayer(100);
            Destroy(gameObject, 1);
        }
    }
}
