using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEditor.Search;
using UnityEngine;

[Serializable]
public class ShopItem
{
    public int price = 100;
    public Color color = new Color(1, 1, 1);
    public bool bought = false;
}

[Serializable]
public class Save
{
    public int coins;
    [SerializeField]
    public List<ShopItem> items;
    public int selectedItem = 0;

    public Save(int coins, List<ShopItem> items, int selectedId)
    {
        this.coins = coins;
        this.items = items;
        this.selectedItem = selectedId;
    }

    public Save()
    {
        this.coins = GameState.coins;
        this.items = GameState.items;
        this.selectedItem = GameState.selectedId;
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
        GameState.items = saveObject.items;
        Debug.Log("Coins from game state: " + GameState.coins);
        Debug.Log("Item size: " + GameState.items.Count);
    }

    public static void SaveState(Save saveObject)
    {
        string json = JsonUtility.ToJson(saveObject);
        File.WriteAllText(filePath, json);
    }
}
