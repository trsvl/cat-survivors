using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : PopUpManager
{
    bool isPressedEsc = false;
    public override void FirstButtonClick()
    {
        Time.timeScale = 1;
        canvas.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            activeButton.Select();
            isPressedEsc = !isPressedEsc;
            if (isPressedEsc)
            {
                Time.timeScale = 0;
                canvas.enabled = true;
            }
            if (!isPressedEsc)
            {
                Time.timeScale = 1;
                canvas.enabled = false;
            }
        }
    }
}
