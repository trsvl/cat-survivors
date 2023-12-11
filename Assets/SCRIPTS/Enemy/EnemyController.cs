using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Transform player;
    SpriteRenderer spriteRenderer;
    public EnemyScriptableObject enemy;
    float localHealth;

    protected virtual void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        localHealth = enemy.health;
    }

    protected virtual void Update()
    {
        if (Vector2.Distance(transform.position, player.position) >= enemy.despawnDistance)
        {
            ReturnEnemy();
        }

         transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemy.moveSpeed * Time.deltaTime);
           
    }
    public void TakeDamage(float damage)
    {
        localHealth -= damage;

        if (localHealth <= 0)
        {
            Instantiate(enemy.expPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Spawner es = FindObjectOfType<Spawner>();
            es.OnEnemyKilled();
        }
        else
        {
            StartCoroutine(FlashWhite());
        }
    }

     IEnumerator FlashWhite()
    {
        Color originalColor = spriteRenderer.color;
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);

        yield return new WaitForSeconds(0.1f);

        spriteRenderer.color = originalColor;
    }


    void ReturnEnemy()
    {
        Spawner es = FindObjectOfType<Spawner>();
        transform.position = player.position + es.relativeSpawnPoints[Random.Range(0, es.relativeSpawnPoints.Count)].position;
    }

}
