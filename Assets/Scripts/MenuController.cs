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
        GameSave.SaveState(new Save(123, GameState.items, GameState.selectedId));
                 
        Debug.Log("Quit");
        Application.Quit();
    }


}
