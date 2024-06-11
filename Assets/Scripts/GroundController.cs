using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    public float speed = 2.0f;
    public float deleteZ;
    public float spawnZ;
    public GameObject groundPrefab;
    
    private bool spawned = false;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);

        if(transform.position.z < spawnZ && !spawned)
        {
            Instantiate(groundPrefab, transform.position + new Vector3(0, 0, 20), Quaternion.identity);
            spawned = true;
        }

        if (transform.position.z < deleteZ)
        {
            Destroy(gameObject);
        }

    }


}
