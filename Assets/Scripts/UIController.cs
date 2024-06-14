using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    void Restart()
    {
        Debug.Log("restart");
    }
}
