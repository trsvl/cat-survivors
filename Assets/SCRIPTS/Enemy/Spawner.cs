using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    private class Wave
    {
        public string waveName;
        public List<EnemyGroup> enemyGroups;
        public int waveQuota; //total number of enemies to spawn in this wave
        public float spawnInterval;
        public int spawnCount; //already spawned
    }

    [System.Serializable]
    private class EnemyGroup
    {
        public string enemyName;
        public int enemyCount; //number to spawn in this wave
        public int spawnCount; //already spawned
        public GameObject enemyPrefab;
    }

    [SerializeField] private List<Wave> waves;
    [SerializeField] private int currentWaveCount;

    [Header("Spawner Attributes")]
    float spawnTimer; //when to spawn the next enemy
    [SerializeField] private int enemiesAlive;
    public int EnemiesAlive
    {
        get { return enemiesAlive; }
    }
    [SerializeField]
    private int maxEnemiesAllowed;
    [SerializeField] private bool maxEnemiesReached = false;
    [SerializeField] private float waveIntreval;
    float waveTimer;

    [Header("Spawn Postitions")]
    [SerializeField] private List<Transform> relativeSpawnPoints;
    public List<Transform> RelativeSpawnPoints
    {
        get { return relativeSpawnPoints; }
    }

    Transform player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        CalculateWaveQuota();
    }
    private void Update()
    {
        spawnTimer += Time.deltaTime;
        waveTimer += Time.deltaTime;

        if ((waves[currentWaveCount].waveQuota == waves[currentWaveCount].spawnCount)
            || ((waves[currentWaveCount].waveQuota == waves[currentWaveCount].spawnCount) && enemiesAlive == 0)
            || (waveTimer >= waveIntreval))
        {
            waveTimer = 0f;
            BeginNextWave();
        }
        //Check if it`s time to spawn the next enemy
        if (spawnTimer >= waves[currentWaveCount].spawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemies();
        }
    }
    void BeginNextWave()
    {
        if (currentWaveCount < waves.Count - 1)
        {
            currentWaveCount++;
            CalculateWaveQuota();
        }
    }
    void CalculateWaveQuota()
    {
        int currentWaveQuota = 0;
        foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
        {
            currentWaveQuota += enemyGroup.enemyCount;
        }

        waves[currentWaveCount].waveQuota = currentWaveQuota;
    }
    void SpawnEnemies()
    {
        //Check if the minimum number of enemies in the wave have been spawned
        if (waves[currentWaveCount].spawnCount < waves[currentWaveCount].waveQuota && !maxEnemiesReached)
        {
            //Spawn each type of enemy until the quota is filled
            foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
            {
                //Check if the minimum number of enemies of this have been spawned
                if (enemyGroup.spawnCount < enemyGroup.enemyCount)
                {
                    if (enemiesAlive >= maxEnemiesAllowed)
                    {
                        maxEnemiesReached = true;
                        return;
                    }

                    int randomIndex = Random.Range(0, relativeSpawnPoints.Count);
                    Instantiate(enemyGroup.enemyPrefab, player.position + relativeSpawnPoints[randomIndex].position, Quaternion.identity);

                    enemyGroup.spawnCount++;
                    waves[currentWaveCount].spawnCount++;
                    enemiesAlive++;
                }
            }
        }
        //Reset the maxEnemies if enemies alive has dropped below the maximum amount
        if (enemiesAlive < maxEnemiesAllowed)
        {
            maxEnemiesReached = false;
        }
    }
    public void OnEnemyKilled()
    {
        enemiesAlive--;
    }
}
