using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingSpawner : MonoBehaviour
{
    public GameObject toppingPrefab1; // Reference to the first topping prefab
    public GameObject toppingPrefab2; // Reference to the second topping prefab
    public GameObject cockroachPrefab; // Reference to the cockroach prefab
    public float spawnInterval = 2f; // Time interval between spawns
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
        GameObject selectedPrefab = Random.Range(0f, 1f) < 0.5f ? GetRandomToppingPrefab() : cockroachPrefab;

        // Instantiate at the random spawn position
        Instantiate(selectedPrefab, randomSpawnPosition, Quaternion.identity);
    }

    GameObject GetRandomToppingPrefab()
    {
        // Randomly choose between two topping prefabs
        return Random.Range(0f, 1f) < 0.5f ? toppingPrefab1 : toppingPrefab2;
    }

    // Draw Gizmos to visualize the spawn area
    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}
