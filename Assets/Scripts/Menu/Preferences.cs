using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Preferences : MonoBehaviour
{
    public GameObject Menu;
    public GameObject NewUser;
    public string color;
    public string text;
    public string hints;
    public string full;
    public string quality;
    public string music;
    public string effects;

    string path;
    string prefPath;
    string defaultPrefs;
    string[] readPrefs;

    // Start is called before the first frame update
    void Start()
    {
        path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        prefPath = path + "/TriniC/Preferences.txt";
        //UpdatePrefs();
        if (!System.IO.File.Exists(@prefPath))
        {
            defaultPrefs = "Colorblind:0 Text:3 Hints:1 Fullscreen:1 Quality:3 Music:1.00 Effects:1.00 end\n";
            System.IO.File.AppendAllText(@prefPath, defaultPrefs);
            Menu.SetActive(false);
            NewUser.SetActive(true);
        }
    }

    private string Between(string s, string first, int firstLength, string second, int subSIndex)
    {
        int firstStringPosition = s.IndexOf(first);
        int secondStringPosition = s.IndexOf(second);
        string stringBetweenTwoStrings = s.Substring(firstStringPosition + firstLength,
            secondStringPosition - firstStringPosition - subSIndex);
        return stringBetweenTwoStrings;
    }

    private void UpdatePrefs()
    {
        path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        prefPath = path + "/TriniC/Preferences.txt";
        readPrefs = System.IO.File.ReadAllLines(@prefPath);
        color = Between(readPrefs[0], "Colorblind:", 11, "Text:", 12);
        //Debug.Log(color);
        text = Between(readPrefs[0], "Text:", 5, "Hints:", 6);
        //Debug.Log(text);
        hints = Between(readPrefs[0], "Hints:", 6, "Fullscreen:", 7);
        //Debug.Log(hints);
        full = Between(readPrefs[0], "Fullscreen:", 11, "Quality:", 12);
        //Debug.Log(full);
        quality = Between(readPrefs[0], "Quality:", 8, "Music:", 9);
        //Debug.Log(quality);
        music = Between(readPrefs[0], "Music:", 6, "Effects:", 7);
        //Debug.Log(music);
        effects = Between(readPrefs[0], "Effects:", 8, "end", 9);
        //Debug.Log(effects);
    }

    public void ReplaceString(string s1, int length1, string s2, string value, int size)
    {
        int s1Index = readPrefs[0].IndexOf(s1);
        string subS1 = readPrefs[0].Substring(s1Index, length1);
        int s2Index = readPrefs[0].IndexOf(s2);
        int length2 = readPrefs[0].Length - subS1.Length - size;
        string subS2 = readPrefs[0].Substring(s2Index, length2);
        string temp = subS1 + value + subS2;
        Debug.Log(s1Index);
        Debug.Log(subS1);
        Debug.Log(s2Index);
        Debug.Log(length2);
        Debug.Log(subS2);
        Debug.Log(temp);
        System.IO.File.WriteAllText(@prefPath, temp);
    }

    public void ToggleColor()
    {
        UpdatePrefs();
        if (color == "0")
        {
            Debug.Log("color was 0");
            color = "1";
            ReplaceString("Colorblind:", 11, " Text:", "1", 1);
        }
        else
        {
            Debug.Log("color was 1");
            color = "0";
            ReplaceString("Colorblind:", 11, " Text:", "0", 1);
        }
    }

    public void ToggleText()
    {
        UpdatePrefs();
        if (text == "3")
        {
            text = "2";
            ReplaceString("Colorblind:", 18, " Hints:", "2", 1);
        }
        else if (text == "2")
        {
            text = "1";
            ReplaceString("Colorblind:", 18, " Hints:", "1", 1);
        }
        else
        {
            text = "3";
            ReplaceString("Colorblind:", 18, " Hints:", "3", 1);
        }
    }

    public void ToggleHints()
    {
        UpdatePrefs();
        if (hints == "0")
        {
            hints = "0";
            ReplaceString("Colorblind:", 26, " Fullscreen:", "1", 1);
        }
        else
        {
            hints = "1";
            ReplaceString("Colorblind:", 26, " Fullscreen:", "0", 1);
        }
    }

    public void ToggleFullscreen()
    {
        UpdatePrefs();
        if (full == "0")
        {
            full = "1";
            ReplaceString("Colorblind:", 39, " Quality:", "1", 1);
        }
        else
        {
            full = "0";
            ReplaceString("Colorblind:", 39, " Quality:", "0", 1);
        }
    }

    public void ToggleQuality()
    {
        UpdatePrefs();
        if (quality == "3")
        {
            quality = "2";
            ReplaceString("Colorblind:", 49, " Music:", "2", 1);
        }
        else if (quality == "2")
        {
            quality = "1";
            ReplaceString("Colorblind:", 49, " Music:", "1", 1);
        }
        else
        {
            quality = "3";
            ReplaceString("Colorblind:", 49, " Music:", "3", 1);
        }
    }

    public void SetMusic(float vol)
    {
        string temp;
        if(Math.Round(vol, 2) < 0)
            temp = "0" + (Math.Round(vol, 2)).ToString();
        else
            temp = (Math.Round(vol, 2)).ToString();
        UpdatePrefs();
        ReplaceString("Colorblind:", 57, " Effects:", (temp), 4);
    }

    public void SetEffects(float vol)
    {
        string temp;
        if (Math.Round(vol, 2) < 0)
            temp = "0" + (Math.Round(vol, 2)).ToString();
        else
            temp = (Math.Round(vol, 2)).ToString();
        UpdatePrefs();
        ReplaceString("Colorblind:", 70, " end", (temp), 4);
    }
}