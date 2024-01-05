using UnityEngine;

public class BoneProjectile : Projectile
{
    Rigidbody2D rb;
    PlayerMovement player;
    SpriteRenderer spriteRenderer;
    BoneController controller;
    float timer = 0f;
    float randomVelocityX;

    void Awake()
    {
        controller = FindObjectOfType<BoneController>();
        weaponData = controller.WeaponData;
    }
    protected override void Start()
    {
        base.Start();

        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        randomVelocityX = Random.Range(-3f, 3f);
        float randomVelocityY = Random.Range(6f, 10f);

        rb.velocity = new Vector2(randomVelocityX, randomVelocityY);
        rb.gravityScale = 2;

        if (randomVelocityX < 0)
        {
            spriteRenderer.flipX = true;
        }
        ChangeLocalScale(2, 1.1f);
        ChangeLocalScale(3, 1.3f);
        ChangeLocalScale(4, 1.5f);
        ChangeLocalScale(5, 2f);
    }
    void ChangeLocalScale(int lvl, float value)
    {
        if (weaponData.level == lvl)
        {
            transform.localScale = transform.localScale * value;
        }
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if (player.MoveDir.y < 0)
        {
            rb.gravityScale = 2;
        }
        if (player.MoveDir.y > 0)
        {
            rb.gravityScale = 0;
        }

        if (timer > 0.5f)
        {
            rb.gravityScale = 2;
        }

        if (randomVelocityX < 0)
        {
            rb.AddTorque(180f * Time.deltaTime);
        }
        if (randomVelocityX > 0)
        {
            rb.AddTorque(-180f * Time.deltaTime);
        }
    }
}
