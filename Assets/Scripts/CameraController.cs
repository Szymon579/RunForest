using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public int distance;
    public int height;
    public Transform player;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, height, -distance);
    }
}
