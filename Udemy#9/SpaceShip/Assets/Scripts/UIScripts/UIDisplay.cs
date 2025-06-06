using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider _healthSlider;
    [SerializeField] Health _PlayerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI _scoreText;
    ScoreKeeper _scoreKeeper;
    private void Awake()
    {
        _scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
    }
    void Start()
    {
        _healthSlider.maxValue = _PlayerHealth.GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        _healthSlider.value = _PlayerHealth.GetHealth();
        _scoreText.text = "Score: " + _scoreKeeper.GetScore().ToString("0000000");
    }
}
