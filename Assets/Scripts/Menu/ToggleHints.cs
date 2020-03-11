using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleHints : MonoBehaviour
{
    public Button button;
    public GameObject menu;
    public GameObject hintsOff;
    public GameObject hintsOn;
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
            if (pref.hints == "0")
            {
                hintsOff.SetActive(true);
                hintsOn.SetActive(false);
            }
            else
            {
                hintsOff.SetActive(false);
                hintsOn.SetActive(true);
            }
            init = true;
        }
    }

    void OnClick()
    {
        Debug.Log("Hints button pressed");
        pref.ToggleHints();
    }
}
