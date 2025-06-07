
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSpwaning : MonoBehaviour
{
    private SpwaningGameAssets _gameAssets;

    public ParticleSystem particleee_;

    private void Start()
    {
        particleee_.Pause();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            particleee_.Play();
            _gameAssets = FindObjectOfType<SpwaningGameAssets>();
            _gameAssets._Stop = false;
            _gameAssets.StartCoroutine(_gameAssets.waitSpawner());
            Destroy(gameObject, 0.4f);

        }
    }


}
