using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameObject SelectBtn;
    public GameObject OpenWithDrawPanel;
    public GameObject OpenTransferPanel;
    public GameObject ErrorPopUp;
    public Bank MyBank;
    public Player MyPlayer;

    public TMP_InputField BankToMoney;
    public TMP_InputField MoneyToBank;
    public TMP_Text ErrorMsg;
    public void WithDraw()
    {
        SelectBtn.SetActive(false);
        OpenWithDrawPanel.SetActive(true);
    }

    public void Transfer()
    {
        SelectBtn.SetActive(false);
        OpenTransferPanel.SetActive(true);
    }

    public void BackSpaceBtn()
    {
        if (OpenWithDrawPanel.activeSelf)
        {
            OpenWithDrawPanel.SetActive(false);
        }
        else if (OpenTransferPanel.activeSelf)
        {
            OpenTransferPanel.SetActive(false) ;
        }
        SelectBtn.SetActive(true);
    }

    //단일책임 원칙
    public void WithdrawMoney(int amount) // 출금 Step1
    {
        MyBank.WithdrawMoney(amount);// Bank.cs가 직접 값을 수정하라고 지시.
    }

    public void TransferMoney(int amount) // 입금 Step1
    {
        MyPlayer.TranferMoney(amount); // 이번엔 Player.cs가 직접 값을 수정하라고 지시.
    }


    // 원하는 값만큼 출금
    public void WithdrawBankToMoney()
    {
        if(BankToMoney != null)
        {
            int nowMoney;
            if(int.TryParse(BankToMoney.text,out nowMoney))
            {
                MyBank.WithdrawMoney(nowMoney);
                Debug.Log("출금되었습니다.");
            }
            else
            {
                BankToMoney.text = "";// 숫자가 아니거나 비어있으면 썼던 글씨 칸 비워주기.
                // 경고창 출력.
                ErrorMsg.text = $"Please, Enter the Number.";
                ErrorPopUp.SetActive(true);
            }
        }
        else if (BankToMoney == null)
        {
            BankToMoney.text = "";// 숫자가 아니거나 비어있으면 썼던 글씨 칸 비워주기.
            // 경고창 출력.
            ErrorMsg.text = $"Please, Enter the Number.";
            ErrorPopUp.SetActive(true);
        }
    }

    // 원하는 값 만큼 입금
    public void TransferMoneyToBank()
    {
        if (MoneyToBank != null)
        {
            int nowBank;
            if (int.TryParse(MoneyToBank.text, out nowBank))
            {
                MyPlayer.TranferMoney(nowBank);
            }
            else
            {
                MoneyToBank.text = "";// 숫자가 아니거나 비어있으면 썼던 글씨 칸 비워주기.
                // 경고창 출력.
                ErrorMsg.text = $"Please, Enter the Number.";
                ErrorPopUp.SetActive(true);
            }
        }
        else if (MoneyToBank == null)
        {
            MoneyToBank.text = "";// 숫자가 아니거나 비어있으면 썼던 글씨 칸 비워주기.
            // 경고창 출력.
            ErrorMsg.text = $"Please, Enter the Number.";
            ErrorPopUp.SetActive(true);
        }
    }

    // 뒤로가기 버튼
    public void CloseErrorPopUp()
    {
        ErrorPopUp.SetActive(false);
    }
}
