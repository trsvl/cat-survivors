using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LastEnemy : EnemyController
{
    NewGameManager newGameManager;
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        if (localHealth <= 0)
        {
            newGameManager = FindObjectOfType<NewGameManager>();
            newGameManager.EnableCanvas();
        }
    }
}
