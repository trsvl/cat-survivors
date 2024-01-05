using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SkillsWeaponsManager : MonoBehaviour
{
    [SerializeField] private Image[] emptyImagesBG;
    [SerializeField] private Image[] emptySuggestedImages;
    [SerializeField] private Button[] buttons;
    [SerializeField] private RectTransform groupButtons;
    [SerializeField] private Sprite[] imagesNoWeapons;
    [SerializeField] private Image[] emptyImages;
    public Image[] EmptyImages { get { return emptyImages; } set { emptyImages = value; } }
    [HideInInspector]
    public List<WeaponScriptableObject> weapons;
    bool isWeapons = true;
    WeaponScriptableObject[] resultArray;
    Canvas canvas;
    PauseManager pauseManager;

    void Awake()
    {
        canvas = GetComponent<Canvas>();
        pauseManager = FindObjectOfType<PauseManager>();
    }
    public void FillImagesWithRandomSprites()
    {
        Time.timeScale = 0;
        pauseManager.IsAllowedPause = false;

        if (isWeapons)
        {
            for (int i = 0; i < 3; i++)
            {
                emptySuggestedImages[i].sprite = null;
            }
            List<WeaponScriptableObject> filteredWeapons = weapons.Where(x => x.level < 5).ToList();
            WeaponScriptableObject[] shuffledWeaponsArray = filteredWeapons.OrderBy(x => Guid.NewGuid()).ToArray();
            int len = shuffledWeaponsArray.Length;

            if (len > 3)
            {
                resultArray = shuffledWeaponsArray.Take(3).ToArray();
            }
            else if (len <= 3 && len > 0)
            {
                resultArray = shuffledWeaponsArray.Take(len).ToArray();
            }
            else
            {
                isWeapons = false;
            }
        }
        if (isWeapons)
        {
            for (int i = 0; i < resultArray.Length; i++)
            {
                emptySuggestedImages[i].sprite = resultArray[i].prefab.GetComponent<SpriteRenderer>().sprite;
            }
        }
        else
        {
            for (int i = 0; i < imagesNoWeapons.Length; i++)
            {
                emptySuggestedImages[i].sprite = imagesNoWeapons[i];
            }
        }
        int availableButtons = 0;

        for (int i = 0; i < buttons.Length; i++)
        {
            if (emptySuggestedImages[i].sprite == null)
            {
                if (buttons[i] != null)
                {
                    buttons[i].gameObject.SetActive(false);
                }
            }
            else
            {
                if (buttons[i] != null)
                {
                    buttons[i].gameObject.SetActive(true);
                    availableButtons += 1;
                }
            }
        }
        buttons[0].Select();

        groupButtons.sizeDelta = new Vector2(availableButtons * 210f + (availableButtons <= 1 ? 0f : (availableButtons - 1) * 10f), groupButtons.sizeDelta.y);
        canvas.enabled = true;
    }
    public void OnButtonClick(Image image)
    {
        pauseManager.IsAllowedPause = true;
        if (isWeapons)
        {
            int index = 0;

            for (int i = 0; i < weapons.Count; i++)
            {
                if (weapons[i].prefab.GetComponent<SpriteRenderer>().sprite.name == image.sprite.name)
                {
                    index = i;
                    break;
                }
            }
            Sprite currentSprite = weapons[index].prefab.GetComponent<SpriteRenderer>().sprite;
            weapons[index].level += 1;

            for (int i = 0; i < emptyImages.Length; i++)
            {
                if (emptyImages[i].sprite && emptyImages[i].sprite == currentSprite)
                {
                    if (weapons[index].level == 2)
                    {
                        emptyImagesBG[i].color = new Color32(153, 255, 153, 255);
                    }
                    if (weapons[index].level == 3)
                    {
                        emptyImagesBG[i].color = new Color32(153, 255, 255, 255);
                    }
                    if (weapons[index].level == 4)
                    {
                        emptyImagesBG[i].color = new Color32(153, 153, 255, 255);
                    }
                    if (weapons[index].level == 5)
                    {
                        emptyImagesBG[i].color = new Color32(255, 204, 153, 255);
                    }
                    break;
                }
                else if (!emptyImages[i].sprite && emptyImages[i].sprite != currentSprite)
                {
                    emptyImages[i].sprite = currentSprite;
                    break;
                }
            }
        }
        else
        {
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();

            if (image.sprite.name == "heart")
            {
                playerHealth.HealthMax += 2;
            }
            if (image.sprite.name == "food")
            {
                playerHealth.Heal(5);
            }
        }
        CountExperience countExperience = FindObjectOfType<CountExperience>();

        if (countExperience.ExpCount >= countExperience.ExpMax)
        {
            countExperience.AgainUpdateExpCount();
        }
        else
        {
            canvas.enabled = false;
            Time.timeScale = 1;
        }
    }
}

