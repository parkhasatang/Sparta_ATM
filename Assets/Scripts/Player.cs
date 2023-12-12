using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public TMP_Text PlayerName;
    public TMP_Text Money;
    public TMP_Text Balance;
    int TestMoney = 10000;
    int TestBalance = 10000;

    private void Awake()
    {
        PlayerName.text = "MinKyu";// 나중에 PlayerPref의 Get으로 회원가입에서 값가져오기
        Money.text = $"Money {TestMoney}";
        Balance.text = $"Balance {TestBalance}";
    }


}
