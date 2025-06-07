using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverPanel;
    public GameObject GameManageR;
    public GameObject Vicroty;

    void Start()
    {

        GameManageR.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameOverPanel.SetActive(false);
        Vicroty.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (GameOverPanel.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            gameOver();
        }

    }
    public void Victory()
    {

        SceneManager.LoadScene("0");
    }
    public void V()
    {
        Vicroty.SetActive(true);
    }
    public void gameOver()
    {
        GameOverPanel.SetActive(true);
        UIController.scoreCount = 0;
    }
    public void restart()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }





}
