using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject[] platformPrefabs; // Array to hold different platform prefabs
    public Transform playerTransform;    // Reference to the player's transform

    private float platformSpacing = 4f;   // Vertical distance between platforms
    private float spawnYPosition = -4f;   // Initial spawn position for platforms
    private float safeZone = 15f;        // Distance from the player where platforms should start despawning
    private List<GameObject> activePlatforms; // List to keep track of active platforms

    void Start()
    {
        activePlatforms = new List<GameObject>();
        
        for (int i = 0; i < 10; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        if (playerTransform.position.y > spawnYPosition - safeZone)
        {
            SpawnPlatform();
            RemoveOldPlatforms();
        }
    }

    void SpawnPlatform()
    {
        GameObject platformPrefab = platformPrefabs[Random.Range(0, platformPrefabs.Length)];

        Vector3 spawnPosition = new Vector3(Random.Range(-3.5f, 3.5f), Random.Range(spawnYPosition - 2, spawnYPosition +2), 0);
        Vector3 EnemyPosition = new Vector3(Random.Range(-3.5f, 3.5f), Random.Range(spawnYPosition - 2, spawnYPosition +2), 0);

        GameObject newPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        activePlatforms.Add(newPlatform);
        spawnYPosition += platformSpacing;
    }

    void RemoveOldPlatforms()
    {
        if (activePlatforms.Count > 15)
        {
            Destroy(activePlatforms[0]);
            activePlatforms.RemoveAt(0);
        }
    }
}