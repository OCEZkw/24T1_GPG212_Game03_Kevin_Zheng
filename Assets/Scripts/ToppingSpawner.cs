using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingSpawner : MonoBehaviour
{
    public GameObject toppingPrefab1; // Reference to the first topping prefab
    public GameObject toppingPrefab2; // Reference to the second topping prefab
    public GameObject cockroachPrefab; // Reference to the cockroach prefab
    public float spawnInterval = 0.2f; // Time interval between spawns
    public Vector3 spawnAreaSize = new Vector3(5f, 2f, 5f); // Size of the random spawn area in 3D

    void Start()
    {
        // Start spawning at regular intervals
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    void SpawnObject()
    {
        // Calculate a random spawn position within the specified area
        Vector3 randomSpawnPosition = new Vector3(
            transform.position.x + Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
            transform.position.y + Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f),
            transform.position.z + Random.Range(-spawnAreaSize.z / 2f, spawnAreaSize.z / 2f)
        );

        // Randomly choose between topping or cockroach prefab
        float randomNumber = Random.Range(0f, 1f);
        GameObject selectedPrefab;
        if (randomNumber < 0.1f)
        {
            selectedPrefab = cockroachPrefab;
        }
        else if (randomNumber < 0.5f)
        {
            selectedPrefab = toppingPrefab1;
        }
        else
        {
            selectedPrefab = toppingPrefab2;
        }

        // Instantiate at the random spawn position
        Instantiate(selectedPrefab, randomSpawnPosition, Quaternion.identity);
    }

    GameObject GetRandomToppingPrefab()
    {
        // Randomly choose between two topping prefabs or the cockroach prefab
        float randomNumber = Random.Range(0f, 1f);
        if (randomNumber < 0.1f)
        {
            return cockroachPrefab;
        }
        else if (randomNumber < 0.9f)
        {
            return toppingPrefab2;
        }
        else
        {
            return toppingPrefab1;
        }
    }

    // Draw Gizmos to visualize the spawn area
    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}
