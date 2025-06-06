using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheat : MonoBehaviour
{
    ColisionHandeler DisablingCoilisions;
    AudioSource DisablingAudtioSorce;
    void Start()
    {
        DisablingCoilisions = GetComponent<ColisionHandeler>();
        DisablingAudtioSorce = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            DisablingCoilisions.disablingcollisions = true;
            DisablingAudtioSorce.enabled = false;
        }
        if (Input.GetKey(KeyCode.L))
        {
            loadScene();
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            OnApplicationQuit();
        }

    }

    void loadScene()
    {

        DisablingCoilisions.ReloadSceneNextLevel();

    }

    private void OnApplicationQuit()
    {
        Application.Quit();
    }

}
