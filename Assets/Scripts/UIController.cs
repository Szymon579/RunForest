using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI distanceText;


    void Start()
    {
        distanceText.text = "elo";
    }

    void Update()
    {
        //int distance = (int)GroundSpawner.speed;
        float distance = GroundSpawner.speed;
        distanceText.text = distance.ToString();
    }
}
