using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartManager : MonoBehaviour
{
    Canvas canvas;
    public Button activeButton;

    void Start()
    {
        canvas = GetComponent<Canvas>();
        activeButton.Select();
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
