using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleFullscreen : MonoBehaviour
{
    public Button button;
    public GameObject menu;
    public GameObject fullOff;
    public GameObject fullOn;
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
            if (pref.full == "0")
            {
                fullOff.SetActive(true);
                fullOn.SetActive(false);

            }
            else
            {
                fullOff.SetActive(false);
                fullOn.SetActive(true);
            }
            init = true;
        }
    }

    void OnClick()
    {
        Debug.Log("Fullscreen button pressed");
        pref.ToggleFullscreen();
    }
}
