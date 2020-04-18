using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChatWithAlexa : MonoBehaviour
{
    public Button button;
    public TMP_InputField inputField;
    public TextMeshProUGUI Input;
    public TextMeshProUGUI Chat0;
    public TextMeshProUGUI Chat1;
    public TextMeshProUGUI Chat2;
    public TextMeshProUGUI Chat3;
    public TextMeshProUGUI Chat4;
    public TextMeshProUGUI Chat5;
    int counter = 1;

    public void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        //Debug.Log("button clicked");
        switch(counter)
        {
            case 1:
                {
                    //Debug.Log("1");
                    Chat0.text = Input.text;
                    Chat1.text = "Hi";
                    break;
                }
            case 2:
                {
                    //Debug.Log("2");
                    Chat2.text = Chat0.text;
                    Chat3.text = Chat1.text;
                    Chat0.text = Input.text;
                    Chat1.text = "yeah, let's play something";
                    break;
                }
            case 3:
                {
                    //Debug.Log("3");
                    Chat4.text = Chat2.text;
                    Chat5.text = Chat3.text;
                    Chat2.text = Chat0.text;
                    Chat3.text = Chat1.text;
                    Chat0.text = Input.text;
                    Chat1.text = "press play, brah";
                    break;
                }
        }
        inputField.text = string.Empty;
        ++counter;
    }
}
