using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetMusic : MonoBehaviour
{
    private AudioSource source;
    public GameObject menu;
    public Slider slid;
    bool init = false;

    Preferences pref;

    void Start()
    {
        source = GetComponent<AudioSource>();
        pref = menu.GetComponent<Preferences>();
    }

    void Update()
    {
        if (init == false)
        {
            Debug.Log(pref.music);
            slid.value = pref.music;
            init = true;
        }
    }

    public void SetVol(float vol)
    {
        source.volume = vol;
        pref.SetMusic(vol);
    }
}
