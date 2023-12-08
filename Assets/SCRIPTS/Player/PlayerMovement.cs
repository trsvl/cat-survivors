using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;

    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;
    [HideInInspector]
    public Vector2 moveDir;
    [HideInInspector]
    public Vector2 lastVector;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastVector = new Vector2(1, 0f);
    }

    void Update()
    {
        InputManagment();
    }

    void FixedUpdate()
    {
        Move();
    }
   
    void InputManagment()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        if (moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
            lastVector = new Vector2(lastHorizontalVector, 0f);

        }
        if (moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
            lastVector = new Vector2(0f, lastVerticalVector);

        }
        if (moveDir.x != 0 && moveDir.y != 0)
        {
            lastVector = new Vector2(lastHorizontalVector, lastVerticalVector);
        }

    }

    void Move()
    {
        rb.velocity = new Vector2 (moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }
   

}
