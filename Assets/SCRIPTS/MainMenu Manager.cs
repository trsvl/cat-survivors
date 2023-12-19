using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
