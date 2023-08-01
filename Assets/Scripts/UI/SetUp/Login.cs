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
        //_InputAccount = transform.Find("InputAccont").GetComponent<InputField>();
        //_InputPassword = transform.Find("InputPassWord").GetComponent<InputField>();
        //_LoginButton = transform.Find("Login").GetComponent<Button>();

        _InputAccount = gameObject.FindComponent<InputField>("InputAccont");
        _InputPassword = gameObject.FindComponent<InputField>("InputPassWord");
        _LoginButton = gameObject.FindComponent<Button>("Login");


        _LoginButton.onClick.AddListener(ButtonLogin);
    }

    private void ButtonLogin()
    {
        Debug.Log("Login Success");
        //连接服务器， 等待返回数据
        //暂时用假数据，直接进入选人界面
        SceneManager.LoadScene("SelectRole");



    }

}
