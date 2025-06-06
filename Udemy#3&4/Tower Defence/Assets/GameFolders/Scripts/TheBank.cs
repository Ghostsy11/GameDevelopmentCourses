using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class TheBank : MonoBehaviour
{
    [SerializeField] int _startingBalance = 150;
    [SerializeField] int currentBalance;

    public int CurrentBalance
    {
        get { return currentBalance; }
    }
    [SerializeField] TextMeshProUGUI disPlayBalance;
    private void Awake()
    {
        currentBalance = _startingBalance;
        UpdateDisPlay();
    }

    public void Deposit(int damount)
    {
        currentBalance += Mathf.Abs(damount);
        UpdateDisPlay();
    }
    public void Withdraw(int wamount)
    {
        currentBalance -= Mathf.Abs(wamount);
        UpdateDisPlay();
        if (currentBalance < 0)
        {
            ReloadScene();
        }
    }
    void UpdateDisPlay()
    {
        disPlayBalance.text = "Gold: " + currentBalance;
    }
    private void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
