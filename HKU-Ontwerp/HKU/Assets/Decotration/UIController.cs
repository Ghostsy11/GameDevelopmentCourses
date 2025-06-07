using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{


    public Text scoreText;
    public static int scoreCount;


    public void Update()
    {
        scoreText.text = "Score: " + Mathf.Round(scoreCount);
    }


}
