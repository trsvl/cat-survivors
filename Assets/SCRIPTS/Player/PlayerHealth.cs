using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject hpBarPrefab;
    [SerializeField] private Image healthBar;
    [SerializeField] private float healthMax;
    public float HealthMax { get { return healthMax; } set { healthMax = value; } }
    [SerializeField] private float damageInterval;
    [SerializeField] private float healInterval;
    [SerializeField] private float healNumber;
    float health;
    float healTimer = 0f;
    float damageTimer = 0f;
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
                        TakeDamage(enemyCol.Enemy.damage);
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
            restartManager.EnableCanvas();
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
            TakeDamage(enemyCol.Enemy.damage);
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
