using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int _goldReward = 25;
    [SerializeField] int _goldPenalty = 25;
    TheBank _bank;
    // Start is called before the first frame update
    void Start()
    {
        _bank = FindObjectOfType<TheBank>();
    }

    public void RewardGold()
    {
        if (_bank == null) { return; }
        _bank.Deposit(_goldReward);
    }

    public void PenaltyGold()
    {
        if (_bank == null) { return; }
        _bank.Withdraw(_goldPenalty);
    }



}
