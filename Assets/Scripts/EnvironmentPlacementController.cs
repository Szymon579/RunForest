using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentPlacementController : MonoBehaviour
{
    public float offset = 3.5f;

    void Start()
    {
        randomizeForestPosition();

    }

    private void randomizeForestPosition()
    {
        float xOffset= 1.9f;
        float zOffset = 10.0f;
        float maxRotation = 360.0f;
        float tiltOffset = 4.0f;

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);

            float x = Random.Range(-xOffset, xOffset);
            float z = Random.Range(-zOffset, zOffset);
            float rotation = Random.Range(0.0f, maxRotation);
            float xTilt = Random.Range(-tiltOffset, tiltOffset);
            float zTilt = Random.Range(-tiltOffset, tiltOffset);

            Debug.Log("random float: " + x);

            child.transform.Translate(new Vector3(x, 0, z));
            child.transform.Rotate(xTilt, rotation, zTilt);

        }
    }


}
