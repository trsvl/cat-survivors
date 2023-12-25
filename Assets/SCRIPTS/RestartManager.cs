using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour
{
    Canvas canvas;

    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    public void RestartClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        canvas.enabled = false;
    }
    public void MainMenuClick(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
        canvas.enabled = false;
    }
    public void EnableRestartCanva()
    {
        Time.timeScale = 0;
        canvas.enabled = true;
    }
}
