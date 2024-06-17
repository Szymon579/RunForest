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

    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        int distance = (int)(GroundSpawner.speed * Time.timeSinceLevelLoad);
        distanceText.text = distance.ToString();

        coinText.text = CollisionController.coins.ToString();

        if (CollisionController.playerCrashed)
            gameOverPanel.SetActive(true);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        CollisionController.playerCrashed = false;
        GroundSpawner.speed = 10.0f;
        gameOverPanel.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        CollisionController.playerCrashed = false;
        GroundSpawner.speed = 10.0f;
        gameOverPanel.SetActive(false);
    }
}
