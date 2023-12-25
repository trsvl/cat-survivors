using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button[] buttons;
    void Awake()
    {
        buttons[0].Select();
    }

    public void ClickStart(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }
}
