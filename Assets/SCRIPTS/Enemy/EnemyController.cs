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
    bool isDamaged = false;
    Color originalColor;
    Animator animator;

    float damageTimer = 0f;
    float damageDuration = 0.2f;
    protected virtual void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        localHealth = enemy.health;
        originalColor = spriteRenderer.color;
    }

    protected virtual void Update()
    {
        if (Vector2.Distance(transform.position, player.position) >= enemy.despawnDistance)
        {
            ReturnEnemy();
        }
        if (isDamaged)
        {
            damageTimer += Time.deltaTime;

            if (damageTimer >= damageDuration)
            {
                spriteRenderer.color = originalColor;
                isDamaged = false;
                damageTimer = 0f; 
            }
        }
         transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemy.moveSpeed * Time.deltaTime);

        if (transform.position.x != 0 || transform.position.y != 0)
        {
            animator.SetBool("Move", true);
            ChangeDir();
        }
        else
        {
            animator.SetBool("Move", false);
        }

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
            spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
            isDamaged = true;
        }
    }

    void ReturnEnemy()
    {
        Spawner es = FindObjectOfType<Spawner>();
        transform.position = player.position + es.relativeSpawnPoints[Random.Range(0, es.relativeSpawnPoints.Count)].position;
    }
    void ChangeDir()
    {
        Vector2 direction = player.position - transform.position;

        if (direction.x < 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }

}
