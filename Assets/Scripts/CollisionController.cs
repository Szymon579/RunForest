using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;
    private Collider col;

    private bool musicPlaying = false;
    private bool powerUP = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();

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
            powerUP = true;
            WaitAndDo(5.0f, () => { powerUP = false; });
            AudioController.instance.PlayPowerSound(this.transform);
            Destroy(other.gameObject);
        }

    }

    private void cursedRagdoll()
    {
        rb.freezeRotation = false;
        rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        rb.AddForce(Vector3.forward * 2, ForceMode.Impulse);
        
        anim.enabled = false;

        GameSave.SaveState(new Save());
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
