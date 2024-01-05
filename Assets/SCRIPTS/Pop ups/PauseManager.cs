using UnityEngine;

public class PauseManager : PopUpManager
{
    bool isPressedEsc = false;
    bool isAllowedPause = true;
    public bool IsAllowedPause { set { isAllowedPause = value; } }

    public override void FirstButtonClick()
    {
        Time.timeScale = 1;
        canvas.enabled = false;
        isPressedEsc = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isAllowedPause)
        {
            isPressedEsc = !isPressedEsc;
            if (isPressedEsc)
            {
                activeButton.Select();
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
