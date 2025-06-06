using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoilisoinHandler : MonoBehaviour
{
    [SerializeField] float _amountOfWaitingSecounds = 1f;
    [SerializeField] ParticleSystem _VFXBOOM;
    private void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        ReloadCurrentSecne();

    }
    private void ReloadCurrentSecne()
    {
        _VFXBOOM.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<PlayerController>().enabled = false;
        Invoke("ReloadLevel", _amountOfWaitingSecounds);

    }

    private void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

}
