using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI coinText;
    public GameObject gameOverPanel;
    public TextMeshProUGUI recordText;

    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        int distance = (int)(GameState.speed_distance * Time.timeSinceLevelLoad);

        
        if (GameState.speed != 0)
        {
            GameState.distance = distance;
        }

        distanceText.text = GameState.distance.ToString();

        coinText.text = GameState.coins.ToString();

        recordText.enabled = false;
        recordText.text = "Best: " + GameState.record.ToString();

        if (GameState.gameOver) {
            recordText.enabled = true;
            gameOverPanel.SetActive(true);
        }

    }

    public void RestartGame()
    {       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameSave.SaveState(new Save());
        GameState.ResetState();
        
        gameOverPanel.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        GameSave.SaveState(new Save());
        GameState.ResetState();
        gameOverPanel.SetActive(false);
    }
}
