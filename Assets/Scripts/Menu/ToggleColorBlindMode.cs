using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class ToggleColorBlindMode : MonoBehaviour
{
    public Button button;
    public GameObject menu;
    public GameObject colorOff;
    public GameObject colorOn;
    bool init = false;

    Preferences pref;

    public void Start()
    {
        button.onClick.AddListener(OnClick);
        pref = menu.GetComponent<Preferences>();
    }

    public void Update()
    {
        if (init == false)
        {
            if (pref.color == "0")
            {
                colorOff.SetActive(true);
                colorOn.SetActive(false);
            }
            else
            {
                colorOff.SetActive(false);
                colorOn.SetActive(true);
            }
            init = true;
        }
    }

    void OnClick()
    {
        Debug.Log("ColorBlind Mode button pressed");
        pref.ToggleColor();
    }
}
