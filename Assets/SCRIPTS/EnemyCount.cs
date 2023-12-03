using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{
    private int enemyCount = 0;
    public Text counterText;

    public static object Instance { get; internal set; }

    void Start()
    {
        counterText = GetComponent<Text>();
    }
    public void UpdateEnemyCount(int amount)
    {
        enemyCount += amount;
        counterText.text = "Enemy count: " + enemyCount;
    }
}
