using UnityEngine;
using UnityEngine.UI;

public class CountEnemies : MonoBehaviour
{
    Text counterText;
    Spawner spawner;
    void Start()
    {
        counterText = GetComponent<Text>();
        spawner = FindObjectOfType<Spawner>();
        counterText.text = "Enemies alive: " + spawner.enemiesAlive;
    }
    private void Update()
    {
        counterText.text = "Enemies alive: " + spawner.enemiesAlive;
    }
    public void UpdateEnemyCount(int amount)
    {
        counterText.text = "Enemies alive: " + spawner.enemiesAlive;
    }
}
