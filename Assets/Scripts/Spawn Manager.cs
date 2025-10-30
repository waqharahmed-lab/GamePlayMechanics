using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnManager : MonoBehaviour
{
   public GameObject enemyPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;

// Start is called before the first frame update
void Start()
{
    SpawnEnemyWave(waveNumber);
    
}

// Update is called once per frame
void Update()
{
    enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;

    if(enemyCount == 0)
        {
            waveNumber++;
        SpawnEnemyWave(waveNumber);
    }
}
void SpawnEnemyWave(int enemyToSpawn)
{
    for (int i = 0; i < enemyToSpawn; i++)
    {
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }
}

private Vector3 GenerateSpawnPosition()
{
    float spawnPosX = Random.Range(-spawnRange, spawnRange);
    float spawnPosZ = Random.Range(-spawnRange, spawnRange);

    Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

    return randomPos;
}
}