using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{
    int enemyCount;
    public Text counterText;

    public static object Instance { get; internal set; }

    void Start()
    {
        counterText = GetComponent<Text>();
    }
    public void UpdateEnemyCount(int amount)
    {
        Spawner es = FindObjectOfType<Spawner>();
        enemyCount = es.enemiesAlive;
        counterText.text = "Enemy count: " + enemyCount;
    }
}
