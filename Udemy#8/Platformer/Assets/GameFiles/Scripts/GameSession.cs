using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameSession : MonoBehaviour
{
    [SerializeField] int _playersLives = 3;
    [SerializeField] int _score = 0;
    [SerializeField] TextMeshProUGUI _liveText;
    [SerializeField] TextMeshProUGUI _CoinsText;
    void Awake()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        _liveText.text = _playersLives.ToString();
        _CoinsText.text = _score.ToString();

    }

    // Update is called once per frame
    public void PorcessPlayerDeath()
    {
        if (_playersLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    public void AddToScore(int _amountofCoins)
    {
        _score += _amountofCoins;
        _CoinsText.text = _score.ToString();
    }
    private void TakeLife()
    {
        _playersLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        _liveText.text = _playersLives.ToString();
    }
    private void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersisit();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }


}
