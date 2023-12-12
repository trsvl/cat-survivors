using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class BubbleMelee : Melee
{
    PlayerMovement playerMovement;

    List<GameObject> markedEnemies;

    float damageInterval = 1f;
    float damageTimer = 0f;

    protected override void Start()
    {
        base.Start();
        markedEnemies = new List<GameObject>();
        playerMovement = FindObjectOfType <PlayerMovement>();
    }

    void Update()
    {
        transform.position = playerMovement.transform.position;

        damageTimer += Time.deltaTime;

        if (damageTimer >= damageInterval)
        {
            DamageEnemiesInsideBubble();
            damageTimer = 0f;
        }
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy") && !markedEnemies.Contains(col.gameObject))
        {
            markedEnemies.Add(col.gameObject);
            EnemyController enemy = col.GetComponent<EnemyController>();
            enemy.TakeDamage(weaponData.damage);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Enemy") && markedEnemies.Contains(col.gameObject))
        {
            markedEnemies.Remove(col.gameObject);
        }
    }

    private void DamageEnemiesInsideBubble()
    {
        for (int i = markedEnemies.Count - 1; i >= 0; i--)
        {
            var enemy = markedEnemies[i];
            enemy.GetComponent<EnemyController>().TakeDamage(weaponData.damage);
        }
    }
}
