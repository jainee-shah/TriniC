using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleQuality : MonoBehaviour
{
    public Button button;
    public GameObject menu;
    public GameObject quality3;
    public GameObject quality2;
    public GameObject quality1;
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
            if (pref.quality == "3")
            {
                quality3.SetActive(true);
                quality2.SetActive(false);
                quality1.SetActive(false);
            }
            else if (pref.quality == "2")
            {
                quality3.SetActive(false);
                quality2.SetActive(true);
                quality1.SetActive(false);
            }
            else
            {
                quality3.SetActive(false);
                quality2.SetActive(false);
                quality1.SetActive(true);
            }
            init = true;
        }
    }

    void OnClick()
    {
        Debug.Log("Quality button pressed");
        pref.ToggleQuality();
    }
}
