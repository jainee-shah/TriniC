using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleResolution : MonoBehaviour
{
    public Button button;
    public GameObject menu;
    public GameObject resolution3;
    public GameObject resolution2;
    public GameObject resolution1;
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
                resolution3.SetActive(true);
                resolution2.SetActive(false);
                resolution1.SetActive(false);
            }
            else if (pref.quality == "2")
            {
                resolution3.SetActive(false);
                resolution2.SetActive(true);
                resolution1.SetActive(false);
            }
            else
            {
                resolution3.SetActive(false);
                resolution2.SetActive(false);
                resolution1.SetActive(true);
            }
            init = true;
        }
    }

    void OnClick()
    {
        Debug.Log("resolution button pressed");
        pref.ToggleQuality();
    }
}
