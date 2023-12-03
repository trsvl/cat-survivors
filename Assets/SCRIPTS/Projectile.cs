using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject destroy;
    public float speedProjectile = 50f;
    public float lifeTime = 2;
    public int damage = 1;
    private Vector2 direction;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
        GetComponent<Rigidbody2D>().velocity = direction.normalized * speedProjectile;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
      
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            if (enemy != null)
            {
                Destroy(gameObject);
                enemy.TakeDamage(damage);
              
            }
        }
    }
}
