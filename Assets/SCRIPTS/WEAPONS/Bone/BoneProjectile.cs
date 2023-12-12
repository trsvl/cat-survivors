using System.Collections;
using UnityEngine;
using UnityEngine.XR;

public class BonedProjectile: Projectile
{
    Rigidbody2D rb;
    
    protected override void Start()
    {
        base.Start();

        rb = GetComponent<Rigidbody2D>();
        PlayerMovement player = FindObjectOfType<PlayerMovement>();


        float randomVelocity = Random.Range(-8f, 8f);

        rb.velocity = new Vector2(randomVelocity, 8f);


    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.Lerp(rb.velocity, Vector2.down * (weaponData.speed * 2f), Time.deltaTime);
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);
    }
   

}
