using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outfitController : MonoBehaviour
{
    public Material pantsMaterial;
    Color defaultColor;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
            pantsMaterial.color = Color.red;
        if (Input.GetKeyUp(KeyCode.Alpha2))
            pantsMaterial.color = Color.blue;

    }
}
