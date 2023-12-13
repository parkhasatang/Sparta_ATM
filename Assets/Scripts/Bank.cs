using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bank : MonoBehaviour
{
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


    public void WithdrawMoney(int amount)
    {
        if (CurrentBalance >= amount)
        {
            CurrentBalance -= amount ;
            MyPlayer.WithdrawMoney(amount);
            UpdateBalance();
            
        }
    }

    public void TranferMoney(int amount)
    {
        CurrentBalance += amount;
        UpdateBalance();
    }
}
