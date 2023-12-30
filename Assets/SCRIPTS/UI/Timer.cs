using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    Text timerText;
    float timer;
    float currentTime;
    void Start()
    {
        timerText = GetComponent<Text>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            timer = 0;
            UpdateTimer();
        }
    }
    void UpdateTimer()
    {
        currentTime++;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
