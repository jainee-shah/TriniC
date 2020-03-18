using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Text.RegularExpressions;

public class PlayerStats : MonoBehaviour
{
    public string Username1;
    public string Password1;
    public string Username2;
    public string Password2;
    private string form;
    private string path;

    public GameObject C4Hours1;
    public GameObject CheckersHours1;
    public GameObject ChessHours1;
    public GameObject C4Games1;
    public GameObject CheckersGames1;
    public GameObject ChessGames1;
    public GameObject C4Wins1;
    public GameObject CheckersWins1;
    public GameObject ChessWins1;
    public GameObject C4Hours2;
    public GameObject CheckersHours2;
    public GameObject ChessHours2;
    public GameObject C4Games2;
    public GameObject CheckersGames2;
    public GameObject ChessGames2;
    public GameObject C4Wins2;
    public GameObject CheckersWins2;
    public GameObject ChessWins2;
    private string[] lines;
    bool user = false, pass = false;

    public void Start()
    {
        path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        Register(Username1, Password1);
        Register(Username2, Password2);

        lines = System.IO.File.ReadAllLines(@path + "/TriniC/Users.txt");
        Login(Username1, Password1, 1);
        Login(Username2, Password2, 2);
    }

    private void Register(string Username, string Password)
    {
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
        if (user && pass)
        {
            form = "user: " + Username + " pass: " + Password + " H1:000" + " H2:000" + " H3:000" + " G1:000" + " G2:000" + " G3:000" + " W1:000" + " W2:000" + " W3:000" + " end\n";
            System.IO.File.AppendAllText(@path + "/TriniC/Users.txt", form);
            Debug.LogWarning("registration successful");
            Debug.Log("form: " + form);
        }
    }

    private void Login(string Username, string Password, int playerNum)
    {
        if (user && pass)
        {
            /*foreach(string s in lines)
                Debug.Log(s);*/
            form = "user: " + Username + " pass: " + Password;
            if (playerNum == 1)
            {
                foreach (string s in lines)
                    if (s.Contains(form))
                    {
                        //selectedPlayer.GetComponent<TextMeshProUGUI>().text = Username;
                        C4Hours1.GetComponent<TextMeshProUGUI>().text = between(s, "H1:", "H2:");
                        CheckersHours1.GetComponent<TextMeshProUGUI>().text = between(s, "H2:", "H3:");
                        ChessHours1.GetComponent<TextMeshProUGUI>().text = between(s, "H3:", "G1:");
                        C4Games1.GetComponent<TextMeshProUGUI>().text = between(s, "G1:", "G2:");
                        CheckersGames1.GetComponent<TextMeshProUGUI>().text = between(s, "G2:", "G3:");
                        ChessGames1.GetComponent<TextMeshProUGUI>().text = between(s, "G3:", "W1:");
                        C4Wins1.GetComponent<TextMeshProUGUI>().text = between(s, "W1:", "W2:");
                        CheckersWins1.GetComponent<TextMeshProUGUI>().text = between(s, "W2:", "W3:");
                        ChessWins1.GetComponent<TextMeshProUGUI>().text = between(s, "W3:", "end");
                    }
            }
            else
            {
                foreach (string s in lines)
                    if (s.Contains(form))
                    {
                        //selectedPlayer.GetComponent<TextMeshProUGUI>().text = Username;
                        C4Hours2.GetComponent<TextMeshProUGUI>().text = between(s, "H1:", "H2:");
                        CheckersHours2.GetComponent<TextMeshProUGUI>().text = between(s, "H2:", "H3:");
                        ChessHours2.GetComponent<TextMeshProUGUI>().text = between(s, "H3:", "G1:");
                        C4Games2.GetComponent<TextMeshProUGUI>().text = between(s, "G1:", "G2:");
                        CheckersGames2.GetComponent<TextMeshProUGUI>().text = between(s, "G2:", "G3:");
                        ChessGames2.GetComponent<TextMeshProUGUI>().text = between(s, "G3:", "W1:");
                        C4Wins2.GetComponent<TextMeshProUGUI>().text = between(s, "W1:", "W2:");
                        CheckersWins2.GetComponent<TextMeshProUGUI>().text = between(s, "W2:", "W3:");
                        ChessWins2.GetComponent<TextMeshProUGUI>().text = between(s, "W3:", "end");
                    }
            }
            Debug.LogWarning("login successful");
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
}
