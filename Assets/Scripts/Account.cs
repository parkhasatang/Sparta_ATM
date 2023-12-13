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

    public void SignUpAccount() // 회원가입창에서 OK누를때 실행될 함수
    {
        PlayerPrefs.SetString("PlayerName", signUpName.text);
        PlayerPrefs.SetString("PlayerID", signUpID.text);
        PlayerPrefs.SetString("PlayerPS",signUpPS.text);
    }

    public void LoginBtn()// 로그인 버튼을 눌렀을 때 Prefs에 저장된 값이랑 일치하는지 판별후 실행
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

    // 에러 팝업 꺼주기
    public void CloseErrorPopUp()
    {
        ErrorPopUp.SetActive(false);
    }

    // 성공 팝업에서 씬 전환해주기
    public void SuccessBtn()
    {
        SceneManager.LoadScene("MainScene");
    }

    void SetPasswordInputField(TMP_InputField value)
    {
        // TMP_InputField의 ContentType을 Password로 설정
        value.contentType = TMP_InputField.ContentType.Password;

        // '*'를 비밀번호 마스크로 사용
        value.inputType = TMP_InputField.InputType.Password;
    }

    //실행하면 안에 텍스트 다 지워준다.
    void ClearInputField()
    {
        signUpName.text = "";
        signUpID.text = "";
        signUpPS.text = "";
        signUpConfirmPS.text = "";
    }
}
