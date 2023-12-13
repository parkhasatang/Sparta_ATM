using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public UiManager uiManager;
    public Bank MyBank;
    public TMP_Text PlayerName;
    public TMP_Text Money;
    
    int CurrentMoney = 100000;

    

    private void Awake()
    {
        PlayerName.text = PlayerPrefs.GetString("PlayerName");
    }

    private void Start()
    {
        UpdateCurrentMoney();
    }

    private void UpdateCurrentMoney()
    {
        Money.text = $"Money {CurrentMoney}";
    }

    public void WithdrawMoney(int amount)// 출금 Step3
    {
        CurrentMoney += amount;
        UpdateCurrentMoney();
    }

    public void TranferMoney(int amount) // 입금 Step2
    {
        if(CurrentMoney >= amount)
        {
            CurrentMoney -= amount;
            MyBank.TranferMoney(amount);
            UpdateCurrentMoney();
        }
        else if (CurrentMoney < amount)
        {
            uiManager.MoneyToBank.text = "";
            uiManager.ErrorMsg.text = $"Not Enough Money";
            uiManager.ErrorPopUp.SetActive(true);
        }
    }
}
