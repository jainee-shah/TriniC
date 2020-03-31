using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddFriend : MonoBehaviour
{
    public TextMeshProUGUI entry;
    string text;
    public GameObject Button1;
    public TextMeshProUGUI Friend1;
    string text1;
    public GameObject Button2;
    public TextMeshProUGUI Friend2;
    string text2;
    public GameObject Button3;
    public TextMeshProUGUI Friend3;
    string text3;
    public GameObject Button4;
    public TextMeshProUGUI Friend4;
    string text4;
    public GameObject Button5;
    public TextMeshProUGUI Friend5;
    string text5;
    // Start is called before the first frame update
    void Start()
    {
        text1 = Friend1.text;
        text2 = Friend2.text;
        text3 = Friend3.text;
        text4 = Friend4.text;
        text5 = Friend5.text;
    }

    public void OnClick()
    {
        text = entry.text;
        if (text.Contains(text1))
        {
            Button1.SetActive(true);
        }
        else if (text.Contains(text2))
        {
            Button2.SetActive(true);
        }
        else if (text.Contains(text3))
        {
            Button3.SetActive(true);
        }
        else if (text.Contains(text4))
        {
            Button4.SetActive(true);
        }
        else if (text.Contains(text5))
        {
            Button5.SetActive(true);
        }
        else
        {
            entry.text = "Friend does not exist";
        }
        entry.GetComponent<TextMeshProUGUI>().text = "";
    }
}
