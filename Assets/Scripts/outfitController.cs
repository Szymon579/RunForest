using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outfitController : MonoBehaviour
{
    public Material pantsMaterial;

    private void Start()
    {
        pantsMaterial.color = GameState.items[GameState.selectedId].color;
    }

    void Update()
    {

    }
}
