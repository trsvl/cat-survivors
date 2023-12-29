using UnityEngine;
using UnityEngine.UI;

public class CountLevel : MonoBehaviour
{
    private int currentLevel = 1;
    public Text lvlText;

    public static object Instance { get; internal set; }

    void Start()
    {
        lvlText = GetComponent<Text>();
        lvlText.text = "Lvl:" + currentLevel;
    }
    public void UpdateLvlCount()
    {
        currentLevel++;
        lvlText.text = "Lvl:" + currentLevel;
    }
}
