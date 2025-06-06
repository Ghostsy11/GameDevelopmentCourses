using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem particleSystem;
    [SerializeField] float AmountofWaiting = 2f;
    [SerializeField] AudioClip crashSFX;
    PlayerController playerController;
    bool _hasCrashed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Snow" && !_hasCrashed)
        {
            _hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControl();
            particleSystem.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", AmountofWaiting);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}

