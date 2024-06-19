using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public GameObject menuPanel;
    public GameObject shopPanel;


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

    public void DisplayShop()
    {
        GameSave.LoadState();
        menuPanel.SetActive(false);
        shopPanel.SetActive(true);
    }

    public void DisplayMenu()
    {
        GameSave.SaveState(new Save(GameState.coins, GameState.items, GameState.selectedId));
        menuPanel.SetActive(true);
        shopPanel.SetActive(false);
    }

    public void QuitGame()
    {
        GameSave.SaveState(new Save(123, GameState.items, GameState.selectedId));
                 
        Debug.Log("Quit");
        Application.Quit();
    }


}
