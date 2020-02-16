using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEffects : MonoBehaviour
{
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void SetVol(float vol)
    {
        source.volume = vol;
    }
}
