using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Rigidbody2D bullet;
    public Rigidbody2D cat;
    public float power = 5f;
    public float delayShoot = 2f;
    private Vector2 shootDirection = Vector2.up;

    private void Start()
    {
        Invoke("Shoot", delayShoot);
    }
    void Update()
    {
        if (cat.velocity != Vector2.zero)
        {
            shootDirection = cat.velocity.normalized;
        }

    }

    void Shoot()
    {
        Vector2 forwardDirection = shootDirection;

        // Instantiate a projectile with the current position and rotation
        Rigidbody2D instance = Instantiate(bullet, transform.position, Quaternion.identity);

        // Apply force to the projectile in the forward direction
        instance.AddForce(forwardDirection * power);
        Invoke("Shoot", delayShoot);
    }
  
}
