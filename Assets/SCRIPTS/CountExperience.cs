using UnityEngine;
using UnityEngine.UI;

public class CountExperience : MonoBehaviour
{
    private int expCount = 0;
    private int expMax = 6;
    public Text counterText;

    public static object Instance { get; internal set; }

    void Start()
    {
        counterText = GetComponent<Text>();
        counterText.text = "Exp: " + expCount + "/" + expMax;
    }
    public void UpdateExpCount(int amount)
    {
        expCount += amount;
        if (expCount >= expMax)
        {
            expCount = 0;
            expMax += 2;
            CountLevel lvl = FindObjectOfType<CountLevel>();

            if (lvl != null)
            {
                lvl.UpdateLvlCount();
            }
        }
        counterText.text = "Exp: " + expCount + "/" + expMax;
    }
}
