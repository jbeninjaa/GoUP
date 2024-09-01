using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] platformPrefabs; // Array to hold different platform prefabs
    public Transform playerTransform;    // Reference to the player's transform
    private float safeZone = 15f;
    private List<GameObject> activePlatforms; // List to keep track of active platforms
    private int lastScore;
    private float spawnPosY;
    [SerializeField] private int difficulty;
    void Start()
    {   
        difficulty = 2;
        activePlatforms = new List<GameObject>();
        spawnPosY = playerTransform.position.y + 15;
    }

    // Update is called once per frame
    void Update()
    {
        int currentScore = GameManager.Instance.GetScore();
        
        if (currentScore < difficulty){
            difficulty = 2;
        }else{
            difficulty = currentScore / 30;
        }
        
        if (playerTransform.position.y >= spawnPosY)
        {
            for(int i =0; i <difficulty; i++){
                SpawnEnemies();
            }
            RemoveOldEnemy();
        }
    }

    void SpawnEnemies(){
        spawnPosY += safeZone;
        GameObject enemyPrefab = platformPrefabs[0];
        Vector3 enemyPosition = new Vector3(Random.Range(-3.5f, 3.5f), Random.Range(spawnPosY - 2, spawnPosY + 2 )+ safeZone, 0);
        GameObject newEnemy = Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);
        activePlatforms.Add(newEnemy);
    }

    void RemoveOldEnemy(){
        if (activePlatforms.Count > 10)
        {
            Destroy(activePlatforms[0]);
            activePlatforms.RemoveAt(0);
        }
    }
}
