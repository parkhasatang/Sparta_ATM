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

    //����å�� ��Ģ
    public void WithdrawMoney(int amount) // ��� Step1
    {
        MyBank.WithdrawMoney(amount);// Bank.cs�� ���� ���� �����϶�� ����.
    }

    public void TransferMoney(int amount) // �Ա� Step1
    {
        MyPlayer.TranferMoney(amount); // �̹��� Player.cs�� ���� ���� �����϶�� ����.
    }


    // ���ϴ� ����ŭ ���
    public void WithdrawBankToMoney()
    {
        if(BankToMoney != null)
        {
            int nowMoney;
            if(int.TryParse(BankToMoney.text,out nowMoney))
            {
                MyBank.WithdrawMoney(nowMoney);
                Debug.Log("��ݵǾ����ϴ�.");
            }
            else
            {
                BankToMoney.text = "";// ���ڰ� �ƴϰų� ��������� ��� �۾� ĭ ����ֱ�.
                // ���â ���.
                ErrorMsg.text = $"Please, Enter the Number.";
                ErrorPopUp.SetActive(true);
            }
        }
        else if (BankToMoney == null)
        {
            BankToMoney.text = "";// ���ڰ� �ƴϰų� ��������� ��� �۾� ĭ ����ֱ�.
            // ���â ���.
            ErrorMsg.text = $"Please, Enter the Number.";
            ErrorPopUp.SetActive(true);
        }
    }

    // ���ϴ� �� ��ŭ �Ա�
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
                MoneyToBank.text = "";// ���ڰ� �ƴϰų� ��������� ��� �۾� ĭ ����ֱ�.
                // ���â ���.
                ErrorMsg.text = $"Please, Enter the Number.";
                ErrorPopUp.SetActive(true);
            }
        }
        else if (MoneyToBank == null)
        {
            MoneyToBank.text = "";// ���ڰ� �ƴϰų� ��������� ��� �۾� ĭ ����ֱ�.
            // ���â ���.
            ErrorMsg.text = $"Please, Enter the Number.";
            ErrorPopUp.SetActive(true);
        }
    }

    // �ڷΰ��� ��ư
    public void CloseErrorPopUp()
    {
        ErrorPopUp.SetActive(false);
    }
}
