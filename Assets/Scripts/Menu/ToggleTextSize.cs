using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleTextSize : MonoBehaviour
{
    public Button button;
    public GameObject menu;
    public GameObject text3;
    public GameObject text2;
    public GameObject text1;
    private TextMesh[] text;

    Preferences pref;

    public void Start()
    {
        button.onClick.AddListener(OnClick);
        pref = menu.GetComponent<Preferences>();
        text = menu.GetComponents<TextMesh>();
    }

    public void Update()
    {
        if (pref.text == "3")
        {
            text3.SetActive(true);
            text2.SetActive(false);
            text1.SetActive(false);
        }
        else if(pref.text == "2")
        {
            text3.SetActive(false);
            text2.SetActive(true);
            text1.SetActive(false);
        }
        else
        {
            text3.SetActive(false);
            text2.SetActive(false);
            text1.SetActive(true);
        }
    }

    void OnClick()
    {
        Debug.Log("Text Size button pressed");
        if (pref.text == "3")
        {
            foreach (var t in text)
            {
                Debug.Log("text was large");
                t.fontSize *= 1;
            }
        }
        else if (pref.text == "2")
        {
            foreach (var t in text)
            {
                Debug.Log("text was medium");
                t.fontSize *= 3;
            }
        }
        else
        {
            foreach (var t in text)
            {
                Debug.Log("text was small");
                t.fontSize *= 2;
            }
        }
        pref.ToggleText();
    }
}
