using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject hpBarPrefab;
    public Image healthBar;
    public float healthMax;
    float health;
    float healTimer = 0f;

    public float healInterval;

    public float healNumber;

    float damageTimer = 0f;
    public float damageInterval;

    List<GameObject> markedEnemies;

    RestartManager restartManager;
    void Start()
    {
        markedEnemies = new List<GameObject>();
        health = healthMax;

        restartManager = FindObjectOfType<RestartManager>();
    }
    void FixedUpdate()
    {
        healTimer += Time.deltaTime;

        if (healTimer >= healInterval)
        {
            Heal(healNumber);
            healTimer = 0f;
        }

        damageTimer += Time.deltaTime;

        if (damageTimer >= damageInterval)
        {
            foreach (GameObject enemyObject in markedEnemies)
            {
                if (enemyObject != null)
                {
                    EnemyController enemyCol = enemyObject.GetComponent<EnemyController>();
                    if (enemyCol != null)
                    {
                        TakeDamage(enemyCol.enemy.damage);
                    }
                }
            }

            damageTimer = 0f; 
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / 10f;

        if (health <= 0)
        {
            restartManager.EnableCanva();
        }
    }
    public void Heal(float heal)
    {
        if (healthMax > health)
        {
            health += heal;
            healthBar.fillAmount = health / 10f;
        }
        else if (healthMax < health)
        {
            health = healthMax;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy") && !markedEnemies.Contains(col.gameObject))
        {
            markedEnemies.Add(col.gameObject);
            EnemyController enemyCol = col.gameObject.GetComponent<EnemyController>();
            TakeDamage(enemyCol.enemy.damage);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy") && markedEnemies.Contains(col.gameObject))
        {
            markedEnemies.Remove(col.gameObject);
        }
    }
   
}
