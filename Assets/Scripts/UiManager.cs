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
    public Bank MyBank;
    public Player MyPlayer;

    public TMP_InputField BankToMoney;
    public TMP_InputField MoneyToBank;
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
    public void WithdrawMoney(int amount)
    {
        MyBank.WithdrawMoney(amount);// Bank.cs�� ���� ���� �����϶�� ����.
    }

    public void TransferMoney(int amount)
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
                // Todo ���â ���.
                Debug.Log("���ڸ� �Է����ּ���.");
            }
        }
        else if (BankToMoney == null)
        {
            BankToMoney.text = "";// ���ڰ� �ƴϰų� ��������� ��� �۾� ĭ ����ֱ�.
            // Todo ���â ���.
            Debug.Log("���ڸ� �Է����ּ���.");
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
                Debug.Log("�ԱݵǾ����ϴ�.");
            }
            else
            {
                MoneyToBank.text = "";// ���ڰ� �ƴϰų� ��������� ��� �۾� ĭ ����ֱ�.
                // Todo ���â ���.
                Debug.Log("���ڸ� �Է����ּ���.");
            }
        }
        else if (MoneyToBank == null)
        {
            MoneyToBank.text = "";// ���ڰ� �ƴϰų� ��������� ��� �۾� ĭ ����ֱ�.
            // Todo ���â ���.
            Debug.Log("���ڸ� �Է����ּ���.");
        }
    }
}
