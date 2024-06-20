using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    public AudioSource source;

    public AudioClip coinClip;
    public AudioClip musicClip;
    public AudioClip deathClip;
    public AudioClip powerClip;
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

    }

    public void PlayCoinSound(Transform soundTransform)
    {
        AudioSource audioSource = Instantiate(source, soundTransform.position, Quaternion.identity);
        audioSource.clip = coinClip;
        audioSource.Play();

        float clipLength = coinClip.length;
        Destroy(audioSource.gameObject, clipLength);
    }

    public void PlayPowerSound(Transform soundTransform)
    {
        AudioSource audioSource = Instantiate(source, soundTransform.position, Quaternion.identity);
        audioSource.clip = powerClip;
        audioSource.Play();

        float clipLength = powerClip.length;
        Destroy(audioSource.gameObject, clipLength);
    }

    public void PlayDeathSound(Transform soundTransform)
    {
        AudioSource audioSource = Instantiate(source, soundTransform.position, Quaternion.identity);
        audioSource.clip = deathClip;
        audioSource.Play();

        float clipLength = deathClip.length;
        Destroy(audioSource.gameObject, clipLength);
    }

    public void PlayMusic()
    {
        AudioSource audioSource = Instantiate(source, transform.position, Quaternion.identity);
        audioSource.clip = backgroundMusic;
        audioSource.volume = 0.05f;
        audioSource.loop = true;
        audioSource.Play();
    }


}
