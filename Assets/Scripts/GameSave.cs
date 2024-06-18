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
    public static string fileName = "save.json";
    
    public static void LoadState()
    {
        JsonUtility.FromJson<Save>(fileName);
    }

    public static void SaveState(Save saveObject)
    {
        string json = JsonUtility.ToJson(saveObject);
        File.WriteAllText(Application.dataPath + "/" + fileName, json);
    }
}
