using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 1;
    private Transform player;
    public float despawnDistance = 10f;
    public GameObject exp;
    private EnemyCount enemyCount;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyCount = GameObject.FindGameObjectWithTag("EnemyCount").GetComponent<EnemyCount>();
        spriteRenderer = GetComponent<SpriteRenderer>();


    }

    private void Update()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);

            if (distance > despawnDistance)
            {
                Destroy(gameObject);
                enemyCount.UpdateEnemyCount(-1);
            }
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Instantiate(exp, transform.position, Quaternion.identity);
            Destroy(gameObject);
            enemyCount.UpdateEnemyCount(-1);
        }
        else
        {
            StartCoroutine(FlashWhite());
        }
    }

    private IEnumerator FlashWhite()
    {
        Color originalColor = spriteRenderer.color;
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);

        yield return new WaitForSeconds(0.1f);

        spriteRenderer.color = originalColor;
    }

}
