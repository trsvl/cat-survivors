using System.Collections.Generic;
using UnityEngine;

public class BubbleMelee : Melee
{
    PlayerMovement playerMovement;
    List<GameObject> markedEnemies;
    const float damageInterval = 1f;
    float damageTimer = 0f;
    BubbleController controller;

    void Awake()
    {
        controller = FindObjectOfType<BubbleController>();
        weaponData = controller.WeaponData;
    }
    protected override void Start()
    {
        base.Start();

        markedEnemies = new List<GameObject>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        ChangeLocalScale(2, 1.2f);
        ChangeLocalScale(3, 1.5f);
        ChangeLocalScale(4, 2f);
        ChangeLocalScale(5, 3f);
    }
    void ChangeLocalScale(int lvl, float value)
    {
        if (weaponData.level == lvl)
        {
            transform.localScale = transform.localScale * value;
        }
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
            
            if (enemy != null)
            {
                enemy.GetComponent<EnemyController>().TakeDamage(weaponData.damage);
            }
            else
            {
                markedEnemies.RemoveAt(i);
            }
        }
    }
}
