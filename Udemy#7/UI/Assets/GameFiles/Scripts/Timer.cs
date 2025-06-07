using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float _timeToCompleteQuestions = 30f;
    [SerializeField] float _timeToShowCorrectAnswer = 30f;
    public bool _loadNextQuestion;
    public bool _isAnswering = false;
    public float fillFraction;

    [SerializeField] float _timeValue;
    void Update()
    {
        UpdateTimer();
    }

    public void CancelTime()
    {
        _timeValue = 0;
    }


    private void UpdateTimer()
    {
        _timeValue -= Time.deltaTime;

        if (_isAnswering)
        {
            if (_timeValue > 0)
            {
                fillFraction = _timeValue / _timeToCompleteQuestions;
            }
            else
            {
                _isAnswering = false;
                _timeValue = _timeToShowCorrectAnswer;
            }

        }
        else
        {
            if (_timeValue > 0)
            {
                fillFraction = _timeValue / _timeToShowCorrectAnswer;

            }
            else
            {
                _isAnswering = true;
                _timeValue = _timeToCompleteQuestions;
                _loadNextQuestion = true;
            }
        }
        Debug.Log(_isAnswering + ": " + _timeValue + " = " + fillFraction);
    }
}
