using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float _scenedelay = 2f;
    ScoreKeeper _scoreKeeper;

    private void Awake()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    public void LoadMainMenu()
    {

        SceneManager.LoadScene(0);
    }
    public void LoadGame()
    {
        _scoreKeeper.ResetScore();
        StartCoroutine(DealyForScene("Game", _scenedelay));

    }
    public void LoadGameOverScreen()
    {
        SceneManager.LoadScene(2);
    }
    public void QuitGame()
    {
        Debug.Log("Quiting");
        Application.Quit();
    }

    IEnumerator DealyForScene(string sceneName, float dealy)
    {
        yield return new WaitForSeconds(dealy);
        SceneManager.LoadScene(sceneName);
    }
}
