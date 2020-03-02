using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayConnectFour()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayCheckers()
    {
        SceneManager.LoadScene(2);
    }
    public void PlayChess()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
