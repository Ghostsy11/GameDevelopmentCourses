using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreBoard : MonoBehaviour
{
    private int _score;
    TMP_Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Start";
    }
    public void ScoreAddUp(int amountToIncrease)
    {
        _score += amountToIncrease;
        scoreText.text = _score.ToString();
    }

}
