using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionsSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string _question = "Enter new question text here";
    [TextArea(2, 6)]
    [SerializeField] string[] _answer = new string[5];
    [SerializeField] int _correctAnswerIndex;

    public string GetQuestion { get { return _question; } }
    public int _GetCorrectAnswerIndex { get { return _correctAnswerIndex; } }
    public string GetAnswerIndex(int index) { return _answer[index]; }



}
