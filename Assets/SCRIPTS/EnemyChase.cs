using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{

    public float moveSpeed = 3f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (player != null)
        {
            // Calculate the direction from the enemy to the player
            Vector3 directionToPlayer = player.position - transform.position;

            // Normalize the direction vector to have a length of 1
            directionToPlayer.Normalize();

            // Move the enemy towards the player
            transform.Translate(directionToPlayer * moveSpeed * Time.deltaTime);
        }
    }
}
