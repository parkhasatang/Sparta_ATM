using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Bank MyBank;
    public TMP_Text PlayerName;
    public TMP_Text Money;
    
    int CurrentMoney = 100000;

    

    private void Awake()
    {
        PlayerName.text = "MinKyu";// 나중에 PlayerPref의 Get으로 회원가입에서 값가져오기
    }

    private void Start()
    {
        UpdateCurrentMoney();
    }

    private void UpdateCurrentMoney()
    {
        Money.text = $"Money {CurrentMoney}";
    }

    public void WithdrawMoney(int amount)
    {
        CurrentMoney += amount;
        UpdateCurrentMoney();
    }

    public void TranferMoney(int amount)
    {
        if(CurrentMoney >= amount)
        {
            CurrentMoney -= amount;
            MyBank.TranferMoney(amount);
            UpdateCurrentMoney();
        }
    }
}
