using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class Save
{
    public int coins;

    public Save(int coins)
    {
        this.coins = coins;
    }
}

public static class GameSave
{
    public static string filePath = Application.dataPath + "/save.json";
    
    public static void LoadState()
    {
        if(!File.Exists(filePath)) 
        {
            return;
        }

        string jsonString = File.ReadAllText(filePath);
        
        Save saveObject = JsonUtility.FromJson<Save>(jsonString);
        
        GameState.coins = saveObject.coins;
        Debug.Log("Coins from game state: " + GameState.coins);
    }

    public static void SaveState(Save saveObject)
    {
        string json = JsonUtility.ToJson(saveObject);
        File.WriteAllText(filePath, json);
    }
}
