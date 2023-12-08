using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class SkillsWeaponsManager : MonoBehaviour
{
    public List<Image> emptyImages;
    public List<Image> emptySuggestedImages;
    public List<WeaponStat> weapons;
    public Button[] buttons;
    void Awake()
    {

        FillImagesWithRandomSprites();
        
    }

    void Start()
    {
       
    }
    void Update()
    {
        
    }

    public void ClickButton(Image image)
    {

        string name = image.sprite.name;
            Debug.Log(name);

      //  weaponScript.IncreaseWeaponLevel(name, 1);

    }

    public void FillImagesWithRandomSprites()
    {

        for (int i = 0; i < 3; i++)
        {
            Debug.Log(emptySuggestedImages);
            emptyImages[i].sprite = weapons[i].sprite;
            emptySuggestedImages[i].sprite = weapons[i].sprite;

        }
    }



}

[Serializable]
public class WeaponStat
{
    public string name;
    public int level;
    public Sprite sprite;

}
