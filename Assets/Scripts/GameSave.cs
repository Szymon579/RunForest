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

    public ShopItem(int price, Color color,bool bought)
    {
        this.price = price;
        this.color = color;
        this.bought = bought;
    }
}

[Serializable]
public class Save
{
    public int coins;
    [SerializeField]
    public List<ShopItem> items = new List<ShopItem>();
    public int selectedItem = 0;
    public int record;

    public Save(int coins, List<ShopItem> items, int selectedId, int record)
    {
        this.coins = coins;
        this.items = items;
        this.selectedItem = selectedId;
        this.record = record;
    }

    public Save()
    {
        this.coins = GameState.coins;
        this.items = GameState.items;
        this.selectedItem = GameState.selectedId;
        this.record = GameState.record;

        //this.items.Add(new ShopItem(100, new Color(1, 0, 0, 1), false));
        //this.items.Add(new ShopItem(200, new Color(0, 1, 0, 1), false));
        //this.items.Add(new ShopItem(300, new Color(0, 0, 1, 1), false));
        //this.items.Add(new ShopItem(400, new Color(0, 1, 1, 1), false));

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
        GameState.record = saveObject.record;
        GameState.selectedId = saveObject.selectedItem;
    }

    public static void SaveState(Save saveObject)
    {
        string json = JsonUtility.ToJson(saveObject);
        File.WriteAllText(filePath, json);
    }
}
