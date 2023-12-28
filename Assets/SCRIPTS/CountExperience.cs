using UnityEngine;
using UnityEngine.UI;

public class CountExperience : MonoBehaviour
{
    public int expCount = 0;
    public int expMax = 6;
    public Text counterText;

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
            expCount -= expMax;
            //expMax += 2;
            CountLevel lvl = FindObjectOfType<CountLevel>();

            if (lvl != null)
            {
                lvl.UpdateLvlCount();
            }
            SkillsWeaponsManager skillsWeaponsManager = FindObjectOfType<SkillsWeaponsManager>();
            skillsWeaponsManager.FillImagesWithRandomSprites();
        }
        counterText.text = "Exp: " + expCount + "/" + expMax;

        
    }
    public void AgainUpdateExpCount()
    {
        if (expCount >= expMax)
        {
            expCount -= expMax;
            //expMax += 2;
            CountLevel lvl = FindObjectOfType<CountLevel>();

            if (lvl != null)
            {
                lvl.UpdateLvlCount();
            }
        }
        counterText.text = "Exp: " + expCount + "/" + expMax;

        SkillsWeaponsManager skillsWeaponsManager = FindObjectOfType<SkillsWeaponsManager>();
        skillsWeaponsManager.FillImagesWithRandomSprites();
    }

}
