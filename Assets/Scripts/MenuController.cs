using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public TextMeshProUGUI coinsText;

    private void Start()
    {
        GameSave.LoadState();
    }

    private void Update()
    {
        coinsText.text = GameState.coins.ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        GameSave.SaveState(new Save(123));
                 
        Debug.Log("Quit");
        Application.Quit();
    }

    public void BuyItem(int price)
    {
        
        
        //if (GameState.coins < price)
        //    return;

        //GameState.coins -= price;
        //Debug.Log("Item bought: ");
    }

}
