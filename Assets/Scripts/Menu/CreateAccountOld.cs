using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;

public class CreateAccountOld : MonoBehaviour
{
    public GameObject username;
    public GameObject password;
    public GameObject confirmPassword;
    private string Username;
    private string Password;
    private string ConfirmPassword;
    private string form;
    private string path;

    public void Start()
    {
        path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
    }

    public void RegisterButton()
    {
        bool user, pass, confPass;
        user = pass = confPass = false;
        if (Username != "")
        {
            //if (!System.IO.File.Exists(@"C:/Users/Michael/Documents/_UnityProjects/TriniC/Assets/Users.txt"))
            {
                user = true;
            }
            /*else
            {
                Debug.LogWarning("username taken");
            }*/
        }
        else
        {
            Debug.LogWarning("username field empty");
        }
        if (Password != "")
        {
            if (Password.Length > 5)
            {
                pass = true;
            }
            else
            {
                Debug.LogWarning("password must be longer than 5 characters");
            }
        }
        else
        {
            Debug.LogWarning("password field empty");
        }
        if (ConfirmPassword != "")
        {
            if (ConfirmPassword == Password)
            {
                confPass = true;
            }
            else
            {
                Debug.LogWarning("passwords do not match");
            }
        }
        else
        {
            Debug.LogWarning("confirm password field empty");
        }
        if (user && pass && confPass)
        {
            form = "user: " + Username + " pass: " + Password + " H1:000" + " H2:000" + " H3:000" + " G1:000" + " G2:000" + " G3:000" + " W1:000" + " W2:000" + " W3:000" + " end\n";
            System.IO.File.AppendAllText(@path + "/TriniC/Users.txt", form);
            username.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";
            confirmPassword.GetComponent<InputField>().text = "";
            Debug.LogWarning("registration successful");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (username.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }
            if (password.GetComponent<InputField>().isFocused)
            {
                confirmPassword.GetComponent<InputField>().Select();
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            RegisterButton();
        }
        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
        ConfirmPassword = confirmPassword.GetComponent<InputField>().text;
    }
}
