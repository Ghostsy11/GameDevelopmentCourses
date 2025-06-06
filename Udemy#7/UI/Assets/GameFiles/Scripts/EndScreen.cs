using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _finalScore;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
    }

    public void ShowFinalScore()
    {
        _finalScore.text = "Congratulations!\nYou got a score of " + scoreKeeper.CalculateScore() + "%";
    }
}
