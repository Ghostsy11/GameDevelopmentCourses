using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI _questionText;
    public List<QuestionsSO> questions = new List<QuestionsSO>();
    QuestionsSO _currentQuestion;


    [Header("Answers")]
    [SerializeField] GameObject[] _answerButtons = new GameObject[4];
    int correctAnswerIndex;
    [SerializeField] bool _hasAnsweredEarly = true;
    [Header("Buttons Colors")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [Header("Timer")]
    [SerializeField] Image _timeImage;
    Timer _timer;

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper _scoreKeeper;

    [Header("Silder")]
    [SerializeField] Slider _progressBar;

    public bool _quizIsComplete;

    Randomm randomm;
    void Awake()
    {

        randomm = GetComponent<Randomm>();
        _timer = FindAnyObjectByType<Timer>();
        _scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
        _progressBar.maxValue = questions.Count;
        _progressBar.value = 0;
    }
    private void Update()
    {
        _timeImage.fillAmount = _timer.fillFraction;
        if (_timer._loadNextQuestion)
        {
            if (_progressBar.value == _progressBar.maxValue)
            {
                _quizIsComplete = true;
                return;
            }
            _hasAnsweredEarly = false;
            GetNextQuestion();
            _timer._loadNextQuestion = false;
        }
        else if (!_hasAnsweredEarly && !_timer._isAnswering)
        {
            DisPlayAnswer(-1);
            SetButtonState(false);
        }
    }

    public void OnAnswerSelected(int index)
    {
        _hasAnsweredEarly = true;
        DisPlayAnswer(index);
        SetButtonState(false);
        _timer.CancelTime();
        scoreText.text = "Score: " + _scoreKeeper.CalculateScore() + "%";
    }

    private void DisPlayAnswer(int index)
    {
        Image buttonImage;
        if (index == _currentQuestion._GetCorrectAnswerIndex)
        {
            _questionText.text = "Correct";
            buttonImage = _answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            _scoreKeeper.IncrementCorrectAnswers();
        }
        else
        {
            correctAnswerIndex = _currentQuestion._GetCorrectAnswerIndex;
            string correctAnswer = _currentQuestion.GetAnswerIndex(correctAnswerIndex);
            _questionText.text = "Sorry the answer was:\n" + correctAnswer;
            buttonImage = _answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }

    private void GetNextQuestion()
    {
        if (questions.Count > 0)
        {
            SetButtonState(true);
            SetDefualtButtonSprite();
            GetRandomQuestion();
            DisplayQuestions();
            _progressBar.value++;
            _scoreKeeper.IncrementQuestionsSeen();
        }
        else
        {

            return;
        }

    }

    private void GetRandomQuestion()
    {
        int indexer = Random.Range(0, questions.Count);
        _currentQuestion = questions[indexer];

        if (questions.Contains(_currentQuestion))
        {
            questions.Remove(_currentQuestion);
        }

    }

    private void DisplayQuestions()
    {
        _questionText.text = _currentQuestion.GetQuestion;
        for (int i = 0; i < _answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = _answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = _currentQuestion.GetAnswerIndex(i);

        }
    }

    private void SetButtonState(bool state)
    {
        for (int i = 0; i < _answerButtons.Length; i++)
        {
            Button button = _answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }

    }

    private void SetDefualtButtonSprite()
    {
        for (int i = 0; i < _answerButtons.Length; i++)
        {
            Image _buttonImage = _answerButtons[i].GetComponent<Image>();
            _buttonImage.sprite = defaultAnswerSprite;
        }
    }
}
