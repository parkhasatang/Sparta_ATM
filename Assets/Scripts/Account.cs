using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Account : MonoBehaviour
{
    public TMP_InputField signUpName;
    public TMP_InputField signUpID;
    public TMP_InputField signUpPS;
    public TMP_InputField signUpConfirmPS;

    public TMP_InputField LoginID;
    public TMP_InputField LoginPS;

    public GameObject ErrorPopUp;
    public TMP_Text ErrorMsg;

    public GameObject SuccessPopUp;
    public TMP_Text SuccessMsg;

    public GameObject SignUpPanel;


    private void Awake()
    {
        SetPasswordInputField(signUpPS);
        SetPasswordInputField(signUpConfirmPS);
        SetPasswordInputField(LoginPS);
    }
    public void ClickSignUpBtn()
    {
        SignUpPanel.SetActive(true);
    }

    public void ClickCancelBtn()
    {
        SignUpPanel.SetActive(false);
    }

    public void ClickOKBtn()
    {
        if (IsNotValid(signUpName) || IsNotValid(signUpID) || IsNotValid(signUpPS) || IsNotValid(signUpConfirmPS))
        {
            ErrorMsg.text = $"Please enter the value!";
            ErrorPopUp.SetActive(true);
            return;
        }
        else if (signUpPS.text != signUpConfirmPS.text)
        {
            ErrorMsg.text = $"Passwords do not match!";
            ErrorPopUp.SetActive(true);
            return;
        }
        SignUpAccount();
        ErrorMsg.text = $"Sign Up Success!";
        ClearInputField();
        ErrorPopUp.SetActive(true);
        SignUpPanel.SetActive(false);
    }

    private bool IsNotValid(TMP_InputField input)
    {
        return string.IsNullOrEmpty(input.text.ToString());
    }

    public void SignUpAccount() // ȸ������â���� OK������ ����� �Լ�
    {
        PlayerPrefs.SetString("PlayerName", signUpName.text);
        PlayerPrefs.SetString("PlayerID", signUpID.text);
        PlayerPrefs.SetString("PlayerPS",signUpPS.text);
    }

    public void LoginBtn()// �α��� ��ư�� ������ �� Prefs�� ����� ���̶� ��ġ�ϴ��� �Ǻ��� ����
    {
        if (LoginID.text == PlayerPrefs.GetString("PlayerID") && LoginPS.text == PlayerPrefs.GetString("PlayerPS"))
        {
            SuccessMsg.text = $"Login Success!";
            SuccessPopUp.SetActive(true);
        }
        else
        {
            ErrorMsg.text = $"Login fail!";
            ErrorPopUp.SetActive(true);
        }
    }

    // ���� �˾� ���ֱ�
    public void CloseErrorPopUp()
    {
        ErrorPopUp.SetActive(false);
    }

    // ���� �˾����� �� ��ȯ���ֱ�
    public void SuccessBtn()
    {
        SceneManager.LoadScene("MainScene");
    }

    void SetPasswordInputField(TMP_InputField value)
    {
        // TMP_InputField�� ContentType�� Password�� ����
        value.contentType = TMP_InputField.ContentType.Password;

        // '*'�� ��й�ȣ ����ũ�� ���
        value.inputType = TMP_InputField.InputType.Password;
    }

    //�����ϸ� �ȿ� �ؽ�Ʈ �� �����ش�.
    void ClearInputField()
    {
        signUpName.text = "";
        signUpID.text = "";
        signUpPS.text = "";
        signUpConfirmPS.text = "";
    }
}
