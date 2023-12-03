using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterMovement : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float runSpeed = 400f;
    float speedX, speedY;
    const string idle = "Idle";
    const string moveLeft = "MoveLeft";
    string currentState;
    bool left = false;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void ChangeAnimationState(string newState)
    {
        if (currentState == newState)
        {
            return;
        }
        animator.Play(newState);
        currentState = newState;
    }
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * runSpeed;
        speedY = Input.GetAxisRaw("Vertical") * runSpeed;

        rb.velocity = new Vector2(speedX, speedY);

        if (speedX > 0 && !left)
        {
            transform.Rotate(0, 180, 0);
            left = true;
        }

        if (speedX < 0 && left)
        {
            transform.Rotate(0, 180, 0);
            left = false;
        }
        if (speedX > 0)
        {
            ChangeAnimationState(moveLeft);
        }
        else if (speedX < 0)
        {
            ChangeAnimationState(moveLeft);
            
        }
        else
        {
            ChangeAnimationState(idle);
        }

    }

}
