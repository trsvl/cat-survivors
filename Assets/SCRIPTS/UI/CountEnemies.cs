using UnityEngine;
using UnityEngine.UI;

public class CountEnemies : MonoBehaviour
{
    Text counterText;
    Spawner spawner;
    int lastKnownEnemiesAlive;

    void Start()
    {
        counterText = GetComponent<Text>();
        spawner = FindObjectOfType<Spawner>();
        lastKnownEnemiesAlive = spawner.EnemiesAlive;
        UpdateText();
    }
    private void Update()
    {
        if (lastKnownEnemiesAlive != spawner.EnemiesAlive)
        {
            lastKnownEnemiesAlive = spawner.EnemiesAlive;
            UpdateText();
        }
    }
    public void UpdateText()
    {
        counterText.text = "Enemies alive: " + spawner.EnemiesAlive;
    }
}
