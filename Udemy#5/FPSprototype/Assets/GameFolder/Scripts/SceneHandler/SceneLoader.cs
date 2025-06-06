using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Working");
            ReloadScene();
        }
    }

    public void ReloadScene()
    {
        Debug.Log("Reloading");
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Debug.Log("Quiting");
        Application.Quit();
    }
}
