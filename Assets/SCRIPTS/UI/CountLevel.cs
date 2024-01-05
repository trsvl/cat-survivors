using UnityEngine;
using UnityEngine.UI;

public class CountLevel : MonoBehaviour
{
    private int currentLevel = 1;
    [SerializeField] private Text lvlText;

    void Start()
    {
        lvlText = GetComponent<Text>();
        lvlText.text = "Lvl: " + currentLevel;
    }
    public void UpdateLvlCount()
    {
        currentLevel++;
        lvlText.text = "Lvl: " + currentLevel;
    }
}
