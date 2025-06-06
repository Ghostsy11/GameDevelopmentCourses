using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;
    [SerializeField] float AmountofWaiting = 2f;
    AudioSource _audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _particleSystem.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", AmountofWaiting);
        }
    }

    private void ReloadScene()
    {

        SceneManager.LoadScene(1);
    }
}
