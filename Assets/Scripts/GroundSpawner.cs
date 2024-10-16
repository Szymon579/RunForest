using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{   
    public float speedDelta = 0.01f;
    public float deleteZ;
    public int numOfVisibleTiles = 5;
    public GameObject groundPrefab;
    public GameObject startPrefab;
    public bool disableMove = false;

    private List<GameObject> groundList = new List<GameObject>();

    void disableMovement(bool condition)
    {
        if(condition)
        {
            GameState.speed = 0f;
            speedDelta = 0f;
        }
    }

    void Start()
    {
        disableMovement(disableMove);

        transform.position = startPrefab.transform.position;
        groundList.Add(startPrefab); //tile already placed on scene

        for (int i = 0; i < numOfVisibleTiles; i++) 
        {
            spawnTile();
        }
            
    }

    void Update()
    {
        if (GameState.gameOver)
            disableMovement(true);
        
        GameState.speed += speedDelta * Time.deltaTime; // accelerate ground independently from framerate
        GameState.speed_distance += speedDelta * Time.deltaTime;

        for (int i = 0; i < groundList.Count; i++)
        {
            groundList[i].transform.Translate(Vector3.back * Time.deltaTime * GameState.speed);

            if (groundList[i].transform.position.z < deleteZ)
            {
                deleteTile();
                spawnTile();
            }
        }           
    }

    void spawnTile()
    {
        if(groundList.Count <= 0) 
        {
            Debug.Log("groundList empty");
            return;
        }

        int lastTile = groundList.Count - 1;
        GameObject tile = Instantiate(groundPrefab, groundList[lastTile].transform.position + new Vector3(0, 0, 20), Quaternion.identity);
        tile.transform.SetParent(transform);
        groundList.Add(tile);
        
    }

    void deleteTile()
    {
        Destroy(groundList[0]);
        groundList.RemoveAt(0);
    }
}
