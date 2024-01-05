using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : PopUpManager
{
    SelectCatManager selectCatManager;

    protected override void Start()
    {
        base.Start();
        activeButton.Select();
        selectCatManager = FindObjectOfType<SelectCatManager>();
    }
    public override void FirstButtonClick()
    {
        selectCatManager.EnableCanvas();
        canvas.enabled = false;
    }
    public override void ExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }
    public override void EnableCanvas()
    {
        activeButton.Select();
        canvas.enabled = true;
    }
}
