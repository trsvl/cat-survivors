using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static SelectCatManager;
public class SelectCatButtonHandler : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    Animator animator;
    SelectCatManager selectCatManager;
    string catName;
    //Image colors
    Transform imageTransform;
    Image image;
    Color notSelectedImageColor = new Color32(200, 200, 200, 120);
    Color defaultImageColor;
    //Border colors
    Transform borderTransform;
    RawImage border;
    Color defaultBorderColor;
    //Text colors
    Transform textTransform;
    TextMeshProUGUI text;
    Color defaultTextColor;
    Color selectedTextColor = new Color32(239, 186, 140, 255);
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        selectCatManager = FindObjectOfType<SelectCatManager>();
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => ButtonClick());

        imageTransform = transform.Find("Image");
        image = imageTransform.GetComponent<Image>();

        borderTransform = transform.Find("Border");
        border = borderTransform.GetComponent<RawImage>();
        defaultBorderColor = border.color;

        textTransform = transform.Find("Text");
        text = textTransform.GetComponent<TextMeshProUGUI>();
        defaultTextColor = text.color;
    }

    public void OnSelect(BaseEventData eventData)
    {
        animator.SetBool("isActive", true);
        image.color = defaultImageColor;
        border.color = defaultBorderColor + new Color32(0, 0, 0, 100);
        text.color = selectedTextColor;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        animator.SetBool("isActive", false);
        image.color = notSelectedImageColor;
        border.color = defaultBorderColor;
        text.color = defaultTextColor;
    }
    public void GetColor(Color color)
    {
        defaultImageColor = color;
    }
    public void GetName(string name)
    {
        catName = name;
    }
    void ButtonClick()
    {
        PassData.catColor = defaultImageColor;
        PassData.catName = catName;
        SceneManager.LoadScene("Game");
        selectCatManager.DisableCanvas();
    }
}
