using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{

    public static bool playerCrashed = false;
    public static int coins = 0;

    private Collider collider;
    private Animator animator;
    private Rigidbody rb;
    private bool musicPlaying = false;

    private void Start()
    {
        collider = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
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
            playerCrashed = true;
            cursedRagdoll();
        }

        //coin collection
        if (other.transform.tag == "Coin")
        {
            coins++;
            Debug.Log("Coins: " + coins);
            AudioController.instance.PlayCoinSound(this.transform);
            Destroy(other.gameObject);
        }
    }

    private void cursedRagdoll()
    {
        rb.freezeRotation = false;
        rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        rb.AddForce(Vector3.forward * 2, ForceMode.Impulse);
        
        animator.enabled = false;
    }

}
