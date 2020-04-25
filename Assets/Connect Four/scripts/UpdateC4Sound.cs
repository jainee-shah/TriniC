using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateC4Sound : MonoBehaviour
{
    public GameObject GC;
    public GameObject music;

    Preferences pref;
    AudioSource AS;
    bool initialized = false;

    // Start is called before the first frame update
    void Start()
    {
        pref = GC.GetComponent<Preferences>();
        AS = music.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!initialized)
            AS.volume = pref.music;
    }
}
