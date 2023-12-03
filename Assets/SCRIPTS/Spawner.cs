using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public Transform character;
    public float interval = 2f;
    public EnemyCount enemyScene;
    private void Start()
    {
        Invoke("SpawnEnemy", 0);
    }

    private void SpawnEnemy()
    {
        Vector2 spawnPosition = new Vector2(
            character.position.x + Random.Range(-8f, 8f), // Adjust the range as needed
            character.position.y + 7f // Spawn above the character
        );

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Vector2 spawnPosition2 = new Vector2(
           character.position.x + 10f, // Adjust the range as needed
           character.position.y + Random.Range(-4f, 4f) // Spawn above the character
       );
        Instantiate(enemyPrefab, spawnPosition2, Quaternion.identity);
        Vector2 spawnPosition3 = new Vector2(
               character.position.x + Random.Range(-8f, 8f), // Adjust the range as needed
               character.position.y - 7f // Spawn above the character
           );
        Instantiate(enemyPrefab, spawnPosition3, Quaternion.identity);

        Vector2 spawnPosition4 = new Vector2(
            character.position.x - 10f, // Adjust the range as needed
            character.position.y + Random.Range(-4f, 4f) // Spawn above the character
        );
        Instantiate(enemyPrefab, spawnPosition4, Quaternion.identity);
        enemyScene.UpdateEnemyCount(4);
        Invoke("SpawnEnemy", interval);
    }
}
