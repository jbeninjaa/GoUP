using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] platformPrefabs;
    [SerializeField] private float minPlatformSpacing = 0.3f; // vertical spacing between platforms
    [SerializeField] private float maxPlatformSpacing = 1.0f; // vertical spacing between platforms
    [SerializeField] private Transform playerTransform;

    private float spawnPositionY = 0f;
    private float despawnPositionY = 5f;
    private List<GameObject> activePlatforms; // List to keep track of active 
    // Start is called before the first frame update
    void Start()
    {
        activePlatforms = new List<GameObject>();
        for (int i = 0; i < 10; i++)
        {
            SpawnPlatform();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.y > spawnPositionY - despawnPositionY)
        {
            SpawnPlatform();
        }
        
    }

    private void SpawnPlatform(){
        
        GameObject platformPrefab = platformPrefabs[Random.Range(0, platformPrefabs.Length)];
        Vector2 spawnPosition = new Vector2(Random.Range(-2f, 2f), spawnPositionY);

        GameObject newPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        activePlatforms.Add(newPlatform);
        spawnPositionY += Random.Range(minPlatformSpacing, maxPlatformSpacing);
    }

    private void DespawnPlatform(){
            if (activePlatforms.Count > 0) {
                GameObject platformToDespawn = activePlatforms[0];
            if (playerTransform.position.y - platformToDespawn.transform.position.y > despawnPositionY) {
                activePlatforms.RemoveAt(0);
                Destroy(platformToDespawn);
            }
        }
    }
}
