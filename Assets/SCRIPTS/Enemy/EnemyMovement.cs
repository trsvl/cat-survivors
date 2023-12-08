using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyScriptableObject enemy;
    Transform player;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }
    void Update()
    {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemy.moveSpeed * Time.deltaTime);
    }
}
