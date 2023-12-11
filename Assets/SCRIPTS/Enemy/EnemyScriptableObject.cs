using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    public GameObject prefab;
    public float damage;
    public float health;
    public float moveSpeed;
    public float despawnDistance;
    public GameObject expPrefab;
}
