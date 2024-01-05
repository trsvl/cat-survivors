using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SelectCatManager : PopUpManager
{
    MainMenuManager mainMenuManager;
    bool isOpenCanvas = false;

    [System.Serializable]
    private class Cat
    {
        public Button button;
        public string name;
        public Color color;
    }
    [SerializeField] private Cat[] cats;

    public static class PassData
    {
        public static string catName;
        public static List<string> catNames;
        public static Color catColor;
    }
    protected override void Start()
    {
        base.Start();
        mainMenuManager = FindObjectOfType<MainMenuManager>();
        List<string> localList = new List<string>();

        foreach (Cat cat in cats)
        {
            localList.Add(cat.name);
            TextMeshProUGUI textMeshPro = cat.button.GetComponentInChildren<TextMeshProUGUI>();
            SelectCatButtonHandler buttonHandler = cat.button.GetComponentInChildren<SelectCatButtonHandler>();
            textMeshPro.text = cat.name;
            buttonHandler.GetColor(cat.color);
            buttonHandler.GetName(cat.name);
        }
        PassData.catNames = localList;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isOpenCanvas)
        {
            mainMenuManager.EnableCanvas();
            canvas.enabled = false;
            isOpenCanvas = false;
        }
    }
    public override void ExitClick()
    {
        mainMenuManager.EnableCanvas();
        canvas.enabled = false;
    }
    public override void EnableCanvas()
    {
        activeButton.Select();
        canvas.enabled = true;
        isOpenCanvas = true;
    }
    public void DisableCanvas()
    {
        canvas.enabled = false;
    }
}
