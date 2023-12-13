using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bank : MonoBehaviour
{
    public UiManager uiManager;
    public Player MyPlayer;
    public TMP_Text Balance;
    int CurrentBalance = 50000;

    

    private void Start()
    {
        UpdateBalance();
    }

    private void UpdateBalance()
    {
        Balance.text = $"Balance {CurrentBalance}";
    }


    public void WithdrawMoney(int amount) // 출금 Step2
    {
        if (CurrentBalance >= amount)
        {
            CurrentBalance -= amount ;
            MyPlayer.WithdrawMoney(amount);
            UpdateBalance();
        }
        else
        {
            uiManager.BankToMoney.text = "";
            uiManager.ErrorMsg.text = $"Not Enough Money";
            uiManager.ErrorPopUp.SetActive(true);
        }
    }

    public void TranferMoney(int amount) // 입금 Step3
    {
        CurrentBalance += amount;
        UpdateBalance();
    }
}
