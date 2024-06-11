using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI coinText;

    void Start()
    {
    }

    void Update()
    {
        int distance = (int)(GroundSpawner.speed * Time.timeSinceLevelLoad);
        distanceText.text = distance.ToString();

        coinText.text = CollisionController.coins.ToString();
    }
}
