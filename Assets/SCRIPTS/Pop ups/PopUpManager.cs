using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PopUpManager : MonoBehaviour
{
    [HideInInspector] public Canvas canvas;
    public Button activeButton;
    void Start()
    {
        canvas = GetComponent<Canvas>();
    }
    public virtual void FirstButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        canvas.enabled = false;
    }
    public virtual void ExitClick()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
        canvas.enabled = false;
    }
    public virtual void EnableCanva()
    {
        activeButton.Select();
        Time.timeScale = 0;
        canvas.enabled = true;
    }
}
