using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEffects : MonoBehaviour
{
    private AudioSource source;
    public GameObject menu;

    Preferences pref;

    void Start()
    {
        source = GetComponent<AudioSource>();
        pref = menu.GetComponent<Preferences>();
    }

    public void SetVol(float vol)
    {
        source.volume = vol;
        pref.SetEffects(vol);
    }
}
