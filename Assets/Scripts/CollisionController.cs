using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CollisionController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;
    private Collider col;
    public Light halo;
    private CapsuleCollider coll;

    private bool musicPlaying = false;
    private bool powerUP = false;
    private bool powerTime = false;

    private Coroutine coruTime ;
    private Coroutine coruPower;

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
            halo.enabled = true;
            if (powerUP)
                StopCoroutine(coruPower);
            powerUP = true;
            coruPower = WaitAndDo(5.0f, () => { powerUP = false; halo.enabled = false;  });
            AudioController.instance.PlayPowerSound(this.transform);
            Destroy(other.gameObject);
        }

        if (other.transform.tag == "PowerTime")
        {
            if (powerTime)
                StopCoroutine(coruTime);
            else
            {
                GameState.speed *= 0.5f;
            }
            powerTime = true;
            coruTime = WaitAndDo(5.0f, () => { GameState.speed *= 2.0f; powerTime = false; });
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


    public Coroutine WaitAndDo(float timeInSeconds, Action action)
    {
        return StartCoroutine(Execute(timeInSeconds, action));
    }

    private IEnumerator Execute(float timeInSeconds, Action action)
    {
        yield return new WaitForSeconds(timeInSeconds);
        if (Application.isPlaying) action();
    }
}
