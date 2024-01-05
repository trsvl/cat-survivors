using UnityEngine;
using static SelectCatManager;

public class PlayerColor : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = PassData.catColor;
    }
}
