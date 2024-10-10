using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CollisionController : MonoBehaviour
{
    
    public Light halo;
    public Slider slowSlider;
    public Slider ghostSlider;

    private Animator anim;
    private Rigidbody rb;
    private Collider col;
    private CapsuleCollider coll;

    private bool musicPlaying = false;
    private bool powerUP = false;
    private bool powerTime = false;
    private Coroutine coruTime;
    private Coroutine coruPower;
    private Coroutine coruGhostSlider;
    private Coroutine coruSlowSlider;


    private void Start()
    {
        halo.enabled = false;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        coll = GetComponent<CapsuleCollider>();

        if (!musicPlaying)
        {
            AudioController.instance.PlayMusic();
            musicPlaying = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Obstacle" && !powerUP)
        {
            Debug.Log("Obstacle hit");
            AudioController.instance.PlayDeathSound(this.transform);
            if (GameState.distance > GameState.record)
                GameState.record = GameState.distance;
            GameState.gameOver = true;
            cursedRagdoll();
        }

        //coin collection
        if (other.transform.tag == "Coin")
        {
            GameState.coins++;
            Debug.Log("Coins: " + GameState.coins);
            AudioController.instance.PlayCoinSound(this.transform);
            Destroy(other.gameObject);
        }

        if (other.transform.tag == "Power")
        {
            //halo.enabled = true;
            if (powerUP)
            {
                StopCoroutine(coruPower);
                StopCoroutine(coruGhostSlider);
            }
                
            powerUP = true;
            coruPower = WaitAndDo(5.0f, ghostSlider, () => { powerUP = false; halo.enabled = false;  });
            AudioController.instance.PlayPowerSound(this.transform);
            Destroy(other.gameObject);
        }

        if (other.transform.tag == "PowerTime")
        {
            //showProgress(slowSlider);
            if (powerTime)
            {
                StopCoroutine(coruTime);
                StopCoroutine(coruSlowSlider);
            }            
            else
            {
                GameState.speed *= 0.8f;
            }
            powerTime = true;
            coruTime = WaitAndDo(5.0f, slowSlider, () => { GameState.speed *= 1.25f; powerTime = false; });
            AudioController.instance.PlayPowerSound(this.transform);
            Destroy(other.gameObject);
        }

    }

    private void cursedRagdoll()
    {

        anim.SetTrigger("death");
        coll.height = 1.0f;
        coll.center = new Vector3(0, 0.5f, 0);
        powerUP = true;
    }


    public Coroutine WaitAndDo(float timeInSeconds, Slider slider, Action action)
    {
        if (slider == ghostSlider)
            coruGhostSlider = StartCoroutine(DecreaseValue(5.0f, slider));
        if (slider == slowSlider)
            coruSlowSlider = StartCoroutine(DecreaseValue(5.0f, slider));

        return StartCoroutine(Execute(timeInSeconds, action));
    }

    private IEnumerator Execute(float timeInSeconds, Action action)
    {
        yield return new WaitForSeconds(timeInSeconds);
        if (Application.isPlaying) action();
    }

    //private Coroutine showProgress(Slider slider)
    //{
    //    slider.value = slider.maxValue;
        
    //    if(slider = ghostSlider)
    //        return StartCoroutine(DecreaseValue(5.0f, slider));
    //    return null;
    //}

    private IEnumerator DecreaseValue(float duration, Slider slider)
    {
        float startValue = slider.maxValue;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            slider.value = Mathf.Lerp(startValue, 0f, elapsedTime / duration);
            yield return null; // Wait for the next frame
        }

        slider.value = slider.minValue; // Ensure the value is set to zero at the end
    }

}
