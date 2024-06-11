using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralObstalePlacer : MonoBehaviour
{
    public Transform parentContainer;
    public GameObject prefab;
    public int numberOfPrefabInstances = 20;
    public float absoluteGroundLevel = 1f;

    private Vector3 generationAreaSize = new Vector3(3f, 1f, 20f);

    void Start()
    {
        // If no parentContainer provided, instances will be generated as children of the generator.
        if (parentContainer == null)
        {
            parentContainer = transform.root;
        }

        gameObject.transform.position = new Vector3(gameObject.transform.position.x, absoluteGroundLevel, gameObject.transform.position.z);

        Generate();
    }


    void Update()
    {
        
    }

    void Generate()
    {
        for (int i = 0; i < numberOfPrefabInstances; i++)
        {
            Vector3 randomPosition = GetRandomPositionInGenerationArea();
            Quaternion randomRotation = Quaternion.identity;
            //Quaternion randomRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
            //Instantiate(prefab, randomPosition, randomRotation);
            Instantiate(prefab, randomPosition, randomRotation, parentContainer.transform);
        }
    }

    Vector3 GetRandomPositionInGenerationArea()
    {
        Vector3 randomPosition = new Vector3(
           //Random.Range(-generationAreaSize.x / 2, generationAreaSize.x / 2),
           //0f,
           Mathf.Round(Random.Range(-generationAreaSize.x / 2, generationAreaSize.x /2)) + 1.5f,
           0f,
           Random.Range(-generationAreaSize.z / 2, generationAreaSize.z / 2)
       );

        return transform.position + randomPosition;
    }
}
