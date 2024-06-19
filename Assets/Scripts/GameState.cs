using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class GameState : MonoBehaviour
{
    public static int coins = 0;
    public static int distance = 0;
    public static float speed = 10.0f;
    public static bool gameOver = false;
    public static Color pantsColor = new Color(0, 1, 0);
    public static List<ShopItem> items = new List<ShopItem>();
    public static int selectedId = 0;
    public static int record = 0;

    public static void ResetState()
    {
        distance = 0;
        speed = 10.0f;
        gameOver = false;
    }
}
