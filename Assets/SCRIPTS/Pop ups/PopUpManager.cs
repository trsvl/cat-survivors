using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour
{
    protected Canvas canvas;
    [SerializeField] protected Button activeButton;
    PauseManager pauseManager;

    protected virtual void Start()
    {
        canvas = GetComponent<Canvas>();
        pauseManager = FindObjectOfType<PauseManager>();
    }
    public virtual void FirstButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        canvas.enabled = false;
        pauseManager.IsAllowedPause = true;
    }
    public virtual void ExitClick()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
        canvas.enabled = false;
        pauseManager.IsAllowedPause = true;
    }
    public virtual void EnableCanvas()
    {
        activeButton.Select();
        Time.timeScale = 0;
        canvas.enabled = true;
        pauseManager.IsAllowedPause = false;
    }
}
