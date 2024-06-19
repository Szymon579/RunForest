using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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

        if (Input.GetKeyDown(KeyCode.F5))
        {
            ResetConfigFile();
        }
            
    }


    void ResetConfigFile()
    {
        string filePath = Application.dataPath;
        string god = File.ReadAllText(filePath + "/save_god_mode.json");

        File.WriteAllText(filePath + "/save.json", god);
        GameSave.LoadState();
        GameSave.SaveState(new Save());

        Debug.Log("Config overwritten!");
    }
}
