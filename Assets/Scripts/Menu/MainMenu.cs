using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public GameObject MainCamera;
    public GameObject DirectionalLight;

    /*public void Disable()
    {
        DirectionalLight.SetActive(false);
    }*/

    public void PlayConnectFour()
    {
        //Disable();
        SceneManager.LoadScene(1);
        
    }
    public void PlayCheckers()
    {
        //Disable();
        SceneManager.LoadScene(2);
    }
    public void PlayChess()
    {
        //Disable();
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
