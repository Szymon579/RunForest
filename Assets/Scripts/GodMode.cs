using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodMode : MonoBehaviour
{
    public GameObject menu;
    public GameObject shop;

    void Start()
    {
        menu.SetActive(true);
        shop.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            GameState.coins += 50; 
            Debug.Log("Coins added");
        }
            
        if (Input.GetKeyDown(KeyCode.F2))
        {
            GameState.coins -= 50;
            Debug.Log("Coins taken");
        }
            
    }
}
