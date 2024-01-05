using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    Rigidbody2D rb;
    [SerializeField] private float lastVerticalVector;
    [SerializeField] private float lastHorizontalVector;
    public float LastHorizontalVector { get { return lastHorizontalVector; } }
    [SerializeField] private Vector2 moveDir;
    public Vector2 MoveDir { get { return moveDir; } }
    [SerializeField] private Vector2 lastVector;
    public Vector2 LastVector { get { return lastVector; } }

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
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }
}
