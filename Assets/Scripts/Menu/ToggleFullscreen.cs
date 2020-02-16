using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleFullscreen : MonoBehaviour
{
    public Button button;

    public void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        if (Screen.fullScreen == true)
        {
            Screen.fullScreen = false;
            Debug.Log("was fullscreen, now windowed");
        }
        else
        {
            Screen.fullScreen = true;
            Debug.Log("was windowed, now fullscreen");
        }
    }
}
