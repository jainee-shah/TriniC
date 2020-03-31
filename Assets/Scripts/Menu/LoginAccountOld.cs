using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Text.RegularExpressions;

public class LoginAccountOld : MonoBehaviour
{
    public GameObject username;
    public GameObject password;
    public GameObject selectedPlayer;
    public GameObject C4Hours;
    public GameObject CheckersHours;
    public GameObject ChessHours;
    public GameObject C4Games;
    public GameObject CheckersGames;
    public GameObject ChessGames;
    public GameObject C4Wins;
    public GameObject CheckersWins;
    public GameObject ChessWins;
    private string Username;
    private string Password;
    private string form;
    private string[] lines;
    private string path;

    public void Start()
    {
        path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
    }

    public void LoginButton()
    {
        bool user, pass, login;
        user = pass = login = false;

        if (Username != "")
        {
            //if (!System.IO.File.Exists(@"C:/Users/Michael/Documents/_UnityProjects/TriniC/Assets/Users.txt"))
            {
                user = true;
                lines = System.IO.File.ReadAllLines(@path + "/TriniC/Users.txt");
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
                Debug.LogWarning("password invalid");
            }
        }
        else
        {
            Debug.LogWarning("password field empty");
        }
        if (user && pass)
        {
            /*foreach(string s in lines)
                Debug.Log(s);*/
            form = "user: " + Username + " pass: " + Password;
            foreach (string s in lines)
                if (s.Contains(form))
                {
                    login = true;
                    selectedPlayer.GetComponent<TextMeshProUGUI>().text = Username;
                    C4Hours.GetComponent<TextMeshProUGUI>().text = between(s, "H1:", "H2:");
                    CheckersHours.GetComponent<TextMeshProUGUI>().text = between(s, "H2:", "H3:");
                    ChessHours.GetComponent<TextMeshProUGUI>().text = between(s, "H3:", "G1:");
                    C4Games.GetComponent<TextMeshProUGUI>().text = between(s, "G1:", "G2:");
                    CheckersGames.GetComponent<TextMeshProUGUI>().text = between(s, "G2:", "G3:");
                    ChessGames.GetComponent<TextMeshProUGUI>().text = between(s, "G3:", "W1:");
                    C4Wins.GetComponent<TextMeshProUGUI>().text = between(s, "W1:", "W2:");
                    CheckersWins.GetComponent<TextMeshProUGUI>().text = between(s, "W2:", "W3:");
                    ChessWins.GetComponent<TextMeshProUGUI>().text = between(s, "W3:", "end");
                }
            if (login)
                Debug.LogWarning("login successful");
            username.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";
        }
    }

    private string between(string s, string first, string second)
    {
        int firstStringPosition = s.IndexOf(first);
        int secondStringPosition = s.IndexOf(second);
        string stringBetweenTwoStrings = s.Substring(firstStringPosition + 3,
            secondStringPosition - firstStringPosition - 4);
        return stringBetweenTwoStrings;
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
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoginButton();
        }
        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
    }
}
