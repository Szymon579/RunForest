using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;

    private bool musicPlaying = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        if(!musicPlaying)
        {
            AudioController.instance.PlayMusic();
            musicPlaying = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Obstacle")
        {
            Debug.Log("Obstacle hit");
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
    }

    private void cursedRagdoll()
    {
        rb.freezeRotation = false;
        rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        rb.AddForce(Vector3.forward * 2, ForceMode.Impulse);
        
        anim.enabled = false;

        GameSave.SaveState(new Save(GameState.coins));
    }

}
