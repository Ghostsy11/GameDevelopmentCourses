using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntertrachtExit : MonoBehaviour
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            _particle.Play();
            UIController.scoreCount -= 1;
            _healtH = FindObjectOfType<HealtH>();
            _healtH.TakeDamageOnPlayer(20);
            Destroy(collision.gameObject);

        }
    }

}

