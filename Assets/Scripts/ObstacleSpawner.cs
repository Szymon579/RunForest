using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject road;
    public GameObject jumpPrefab;
    public GameObject slidePrefab;
    public GameObject dodgePrefab;
    public GameObject coinPrefab;

    public int noObstacles = 3;

    private float height = 0.5f;
    private Dictionary<int, int> obstacles = new Dictionary<int, int>();

    //obstacle placement: x = -1:1, y = 1.5, z = -10:10

    void Start()
    {
        

        int i = 0;
        while (i < noObstacles)
        {
            int key = Random.Range(-10, 10);
            int value = Random.Range(0, 100);
            int type = Random.Range(0, 100);

            value = value % 3 - 1;
            type = type % 4;
            

            if (obstacles.ContainsKey(key))
                continue;

            obstacles.Add(key, value);
            i++;


            //GameObject prefab = new GameObject();
            GameObject prefab = null;

            if (type == 0)
                prefab = jumpPrefab;
            else if (type == 1)
                prefab = slidePrefab;
            else if (type == 2)
                prefab = dodgePrefab;
            else if (type == 3)
                prefab = coinPrefab;

            if (prefab == null)
            {
                Debug.Log("Obstacle prefab is null");
                continue;
            }


            GameObject obstacle = Instantiate(prefab, road.transform.position + new Vector3(value, 0.5f, key), Quaternion.identity, transform);
            obstacle.transform.SetParent(transform);
        }

    }

    void Update()
    {
        
    }


}
