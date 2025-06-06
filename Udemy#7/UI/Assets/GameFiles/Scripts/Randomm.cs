using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomm : MonoBehaviour
{
    Quiz quiz;
    int n;
    private void Start()
    {
        quiz = GetComponent<Quiz>();
    }

    public void GetRandomQuestions()
    {


        int index = Random.Range(0, quiz.questions.Count);
    }

}
