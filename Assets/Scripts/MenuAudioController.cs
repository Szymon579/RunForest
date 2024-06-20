using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class MenuAudioController : MonoBehaviour
{
    public static MenuAudioController instance;
    public AudioSource musicSource;
    public AudioSource effectSource;

    public AudioClip noMoneyClip;
    public AudioClip purchaseClip;
    public AudioClip backgroundMusic;

    private void Awake() //singleton pattern
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Start()
    {
        PlayMusic();
    }

    public void PlayMusic()
    {
        musicSource.clip = backgroundMusic;
        musicSource.volume = 0.03f;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayPurchase()
    {
        effectSource.clip = purchaseClip;
        effectSource.volume = 0.2f;
        effectSource.loop = false;
        effectSource.Play();
    }

    public void PlayError()
    {
        effectSource.clip = noMoneyClip;
        effectSource.volume = 0.5f;
        effectSource.loop = false;
        effectSource.Play();
    }



}
