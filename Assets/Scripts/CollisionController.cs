using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{

    private int coin = 0;
    private Collider myCollider;

    private void Start()
    {
        myCollider = GetComponent<CapsuleCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Obstacle")
        {
            Debug.Log("Obstacle hit");

        }

        //coin collection
        if (other.transform.tag == "Coin")
        {
            coin++;
            Debug.Log("Coins: " + coin);
        
            Destroy(other.gameObject);
        }
    }

}
