using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToggleTextSize : MonoBehaviour
{
    public Button button;
    public GameObject menu;
    public GameObject text3;
    public GameObject text2;
    public GameObject text1;
    bool init = false;
    private static int NUMTEXTS = 88;

    public GameObject mainHeaderTitle;
    public GameObject mainHeaderTm;
    public GameObject mainHeaderCo;
    public GameObject mainPlay1;
    public GameObject mainPlay2;
    public GameObject mainPlay3;
    public GameObject mainCredits;
    public GameObject mainQuit;
    public GameObject mainStats;
    public GameObject mainOptions;
    public GameObject mainVersion;

    public GameObject changePlayerHeaderTitle;
    public GameObject changePlayerHeaderTm;
    public GameObject changePlayerHeaderCo;
    public GameObject changePlayerHeaderHeader2;
    public GameObject changePlayerPlayer1;
    public GameObject changePlayerPlayer2;
    public GameObject changePlayerGame1;
    public GameObject changePlayerGame2;
    public GameObject changePlayerGame3;
    public GameObject changePlayerHours11;
    public GameObject changePlayerHours21;
    public GameObject changePlayerHours12;
    public GameObject changePlayerHours22;
    public GameObject changePlayerHours13;
    public GameObject changePlayerHours23;
    public GameObject changePlayerGames11;
    public GameObject changePlayerGames21;
    public GameObject changePlayerGames12;
    public GameObject changePlayerGames22;
    public GameObject changePlayerGames13;
    public GameObject changePlayerGames23;
    public GameObject changePlayerWins11;
    public GameObject changePlayerWins21;
    public GameObject changePlayerWins12;
    public GameObject changePlayerWins22;
    public GameObject changePlayerWins13;
    public GameObject changePlayerWins23;
    public GameObject changePlayerBack;

    public GameObject playerHeaderTitle;
    public GameObject playerHeaderTm;
    public GameObject playerHeaderCo;
    public GameObject playerHeaderHeader2;
    public GameObject playerLogin1Login;
    public GameObject playerLogin2Login;
    public GameObject playerRegisterCreate;
    public GameObject playerBack;

    public GameObject optionsHeaderTitle;
    public GameObject optionsHeaderTm;
    public GameObject optionsHeaderCo;
    public GameObject optionsHeaderHeader2;
    public GameObject optionsAccessibility;
    public GameObject optionsGraphics;
    public GameObject optionsSound;
    public GameObject optionsBack;

    public GameObject accessibilityHeaderTitle;
    public GameObject accessibilityHeaderTm;
    public GameObject accessibilityHeaderCo;
    public GameObject accessibilityHeaderHeader2;
    public GameObject accessibilityColorOff;
    public GameObject accessibilityColorOn;
    public GameObject accessibilityText3;
    public GameObject accessibilityText2;
    public GameObject accessibilityText1;
    public GameObject accessibilityHintsOn;
    public GameObject accessibilityHintsOff;
    public GameObject accessibilityBack;

    public GameObject graphicsHeaderTitle;
    public GameObject graphicsHeaderTm;
    public GameObject graphicsHeaderCo;
    public GameObject graphicsHeaderHeader2;
    public GameObject graphicsFullscreen;
    public GameObject graphicsWindowed;
    public GameObject graphicsQuality3;
    public GameObject graphicsQuality2;
    public GameObject graphicsQuality1;
    public GameObject graphicsBack;

    public GameObject soundHeaderTitle;
    public GameObject soundHeaderTm;
    public GameObject soundHeaderCo;
    public GameObject soundHeaderHeader2;
    public GameObject soundBack;

    public GameObject creditsHeaderTitle;
    public GameObject creditsHeaderTm;
    public GameObject creditsHeaderCo;
    public GameObject creditsHeaderHeader2;
    public GameObject creditsCredits;
    public GameObject creditsBack;

    private TextMeshProUGUI[] texts = new TextMeshProUGUI[NUMTEXTS];
    
    Preferences pref;
    

    public void Start()
    {
        button.onClick.AddListener(OnClick);
        pref = menu.GetComponent<Preferences>();

        texts[0] = mainHeaderTitle.GetComponent<TextMeshProUGUI>();
        texts[1] = mainHeaderTm.GetComponent<TextMeshProUGUI>();
        texts[2] = mainHeaderCo.GetComponent<TextMeshProUGUI>();
        texts[3] = mainPlay1.GetComponent<TextMeshProUGUI>();
        texts[4] = mainPlay2.GetComponent<TextMeshProUGUI>();
        texts[5] = mainPlay3.GetComponent<TextMeshProUGUI>();
        texts[6] = mainCredits.GetComponent<TextMeshProUGUI>();
        texts[7] = mainQuit.GetComponent<TextMeshProUGUI>();
        texts[8] = mainStats.GetComponent<TextMeshProUGUI>();
        texts[9] = mainOptions.GetComponent<TextMeshProUGUI>();
        texts[10] = mainVersion.GetComponent<TextMeshProUGUI>();
        texts[11] = changePlayerHeaderTitle.GetComponent<TextMeshProUGUI>();
        texts[12] = changePlayerHeaderTm.GetComponent<TextMeshProUGUI>();
        texts[13] = changePlayerHeaderCo.GetComponent<TextMeshProUGUI>();
        texts[14] = changePlayerHeaderHeader2.GetComponent<TextMeshProUGUI>();
        texts[15] = changePlayerPlayer1.GetComponent<TextMeshProUGUI>();
        texts[16] = changePlayerPlayer2.GetComponent<TextMeshProUGUI>();
        texts[17] = changePlayerGame1.GetComponent<TextMeshProUGUI>();
        texts[18] = changePlayerGame2.GetComponent<TextMeshProUGUI>();
        texts[19] = changePlayerGame3.GetComponent<TextMeshProUGUI>();
        texts[20] = changePlayerHours11.GetComponent<TextMeshProUGUI>();
        texts[21] = changePlayerHours21.GetComponent<TextMeshProUGUI>();
        texts[22] = changePlayerHours12.GetComponent<TextMeshProUGUI>();
        texts[23] = changePlayerHours22.GetComponent<TextMeshProUGUI>();
        texts[24] = changePlayerHours13.GetComponent<TextMeshProUGUI>();
        texts[25] = changePlayerHours23.GetComponent<TextMeshProUGUI>();
        texts[26] = changePlayerGames11.GetComponent<TextMeshProUGUI>();
        texts[27] = changePlayerGames21.GetComponent<TextMeshProUGUI>();
        texts[28] = changePlayerGames12.GetComponent<TextMeshProUGUI>();
        texts[29] = changePlayerGames22.GetComponent<TextMeshProUGUI>();
        texts[30] = changePlayerGames13.GetComponent<TextMeshProUGUI>();
        texts[31] = changePlayerGames23.GetComponent<TextMeshProUGUI>();
        texts[32] = changePlayerWins11.GetComponent<TextMeshProUGUI>();
        texts[33] = changePlayerWins21.GetComponent<TextMeshProUGUI>();
        texts[34] = changePlayerWins12.GetComponent<TextMeshProUGUI>();
        texts[35] = changePlayerWins22.GetComponent<TextMeshProUGUI>();
        texts[36] = changePlayerWins13.GetComponent<TextMeshProUGUI>();
        texts[37] = changePlayerWins23.GetComponent<TextMeshProUGUI>();
        texts[38] = changePlayerBack.GetComponent<TextMeshProUGUI>();
        texts[39] = playerHeaderTitle.GetComponent<TextMeshProUGUI>();
        texts[40] = playerHeaderTm.GetComponent<TextMeshProUGUI>();
        texts[41] = playerHeaderCo.GetComponent<TextMeshProUGUI>();
        texts[42] = playerHeaderHeader2.GetComponent<TextMeshProUGUI>();
        texts[43] = playerLogin1Login.GetComponent<TextMeshProUGUI>();
        texts[44] = playerLogin2Login.GetComponent<TextMeshProUGUI>();
        texts[45] = playerRegisterCreate.GetComponent<TextMeshProUGUI>();
        texts[46] = playerBack.GetComponent<TextMeshProUGUI>();
        texts[47] = optionsHeaderTitle.GetComponent<TextMeshProUGUI>();
        texts[48] = optionsHeaderTm.GetComponent<TextMeshProUGUI>();
        texts[49] = optionsHeaderCo.GetComponent<TextMeshProUGUI>();
        texts[50] = optionsHeaderHeader2.GetComponent<TextMeshProUGUI>();
        texts[51] = optionsAccessibility.GetComponent<TextMeshProUGUI>();
        texts[52] = optionsGraphics.GetComponent<TextMeshProUGUI>();
        texts[53] = optionsSound.GetComponent<TextMeshProUGUI>();
        texts[54] = optionsBack.GetComponent<TextMeshProUGUI>();
        texts[55] = accessibilityHeaderTitle.GetComponent<TextMeshProUGUI>();
        texts[56] = accessibilityHeaderTm.GetComponent<TextMeshProUGUI>();
        texts[57] = accessibilityHeaderCo.GetComponent<TextMeshProUGUI>();
        texts[58] = accessibilityHeaderHeader2.GetComponent<TextMeshProUGUI>();
        texts[59] = accessibilityColorOff.GetComponent<TextMeshProUGUI>();
        texts[60] = accessibilityColorOn.GetComponent<TextMeshProUGUI>();
        texts[61] = accessibilityText3.GetComponent<TextMeshProUGUI>();
        texts[62] = accessibilityText2.GetComponent<TextMeshProUGUI>();
        texts[63] = accessibilityText1.GetComponent<TextMeshProUGUI>();
        texts[64] = accessibilityHintsOn.GetComponent<TextMeshProUGUI>();
        texts[65] = accessibilityHintsOff.GetComponent<TextMeshProUGUI>();
        texts[66] = accessibilityBack.GetComponent<TextMeshProUGUI>();
        texts[67] = graphicsHeaderTitle.GetComponent<TextMeshProUGUI>();
        texts[68] = graphicsHeaderTm.GetComponent<TextMeshProUGUI>();
        texts[69] = graphicsHeaderCo.GetComponent<TextMeshProUGUI>();
        texts[70] = graphicsHeaderHeader2.GetComponent<TextMeshProUGUI>();
        texts[71] = graphicsFullscreen.GetComponent<TextMeshProUGUI>();
        texts[72] = graphicsWindowed.GetComponent<TextMeshProUGUI>();
        texts[73] = graphicsQuality3.GetComponent<TextMeshProUGUI>();
        texts[74] = graphicsQuality2.GetComponent<TextMeshProUGUI>();
        texts[75] = graphicsQuality1.GetComponent<TextMeshProUGUI>();
        texts[76] = graphicsBack.GetComponent<TextMeshProUGUI>();
        texts[77] = soundHeaderTitle.GetComponent<TextMeshProUGUI>();
        texts[78] = soundHeaderTm.GetComponent<TextMeshProUGUI>();
        texts[79] = soundHeaderCo.GetComponent<TextMeshProUGUI>();
        texts[80] = soundHeaderHeader2.GetComponent<TextMeshProUGUI>();
        texts[81] = soundBack.GetComponent<TextMeshProUGUI>();
        texts[82] = creditsHeaderTitle.GetComponent<TextMeshProUGUI>();
        texts[83] = creditsHeaderTm.GetComponent<TextMeshProUGUI>();
        texts[84] = creditsHeaderCo.GetComponent<TextMeshProUGUI>();
        texts[85] = creditsHeaderHeader2.GetComponent<TextMeshProUGUI>();
        texts[86] = creditsCredits.GetComponent<TextMeshProUGUI>();
        texts[87] = creditsBack.GetComponent<TextMeshProUGUI>();
    }

    public void StartTextSize(int size)
    {
        if (size == 1)
        {
            foreach (TextMeshProUGUI i in texts)
            {
                i.fontSize *= (float)(1 / 1.44);
            }
        }
        else if (size == 2)
        {
            foreach (TextMeshProUGUI i in texts)
            {
                i.fontSize *= (float)(1 / 1.2);
            }
        }
    }

    public void Update()
    {
        if (init == false)
        {
            if (pref.text == "3")
            {
                text3.SetActive(true);
                text2.SetActive(false);
                text1.SetActive(false);
            }
            else if (pref.text == "2")
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
            init = true;
        }
    }

    void OnClick()
    {
        Debug.Log("Text Size button pressed");
        if (pref.text == "3")
        {
            Debug.Log("text was large");
            ChangeSize(3);
        }
        else if (pref.text == "2")
        {
            Debug.Log("text was medium");
            ChangeSize(2);
        }
        else
        {
            Debug.Log("text was small");
            ChangeSize(1);
        }
        pref.ToggleText();
    }

    void ChangeSize(int size)
    {
        switch(size)
        {
            case 3:
                {
                    foreach (TextMeshProUGUI i in texts)
                    {
                        i.fontSize *= (float)(1/1.44); 
                    }
                    break;
                }
            default:
                {
                    foreach (TextMeshProUGUI i in texts)
                    {
                        i.fontSize *= (float)1.2;
                    }
                    break;
                }
        }
    }
}
