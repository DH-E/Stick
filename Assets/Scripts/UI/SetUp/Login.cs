using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    private InputField _InputAccount;
    private InputField _InputPassword;
    private Button _LoginButton;
    // Start is called before the first frame update
    void Start()
    {
        _InputAccount = transform.Find("InputAccont").GetComponent<InputField>();
        _InputPassword = transform.Find("InputPassWord").GetComponent<InputField>();
        _LoginButton = transform.Find("Login").GetComponent<Button>();

        _LoginButton.onClick.AddListener(ButtonLogin);
    }

    private void ButtonLogin()
    {
        Debug.Log("Login Success");
        //���ӷ������� �ȴ���������
        //��ʱ�ü����ݣ�ֱ�ӽ���ѡ�˽���
        SceneManager.LoadScene("SelectRole");

        

    }

}