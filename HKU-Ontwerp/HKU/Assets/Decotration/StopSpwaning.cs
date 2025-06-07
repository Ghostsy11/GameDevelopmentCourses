using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSpwaning : MonoBehaviour
{
    private SpwaningGameAssets gameAssets;
    public ParticleSystem particle11;


    private void Start()
    {
        particle11.Pause();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            particle11.Play();
            gameAssets = FindObjectOfType<SpwaningGameAssets>();
            gameAssets._Stop = true;
            Destroy(gameObject, 1f);

        }
    }
}
