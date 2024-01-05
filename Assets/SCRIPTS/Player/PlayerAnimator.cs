using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator animator;
    PlayerMovement playerMovement;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (playerMovement.MoveDir.x != 0 || playerMovement.MoveDir.y != 0)
        {
            animator.SetBool("Move", true);
            ChangeDir();
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }
    void ChangeDir()
    {
        if (playerMovement.LastHorizontalVector < 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }
}
