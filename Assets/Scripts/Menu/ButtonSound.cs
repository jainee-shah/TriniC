using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    //DEFUNCT
    public AudioClip sound;

    private Button button;
    private AudioSource source;

    void Start()
    {
        button = GetComponent<Button>();
        gameObject.AddComponent<AudioSource>();
        source = GetComponent<AudioSource>();
        source.clip = sound;
        button.onClick.AddListener(() => PlaySound());
    }

    void PlaySound()
    {
        source.PlayOneShot(sound);
        Debug.Log("clicked");
    }
}
