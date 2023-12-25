using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected Vector3 direction;
    int currentPierce;
    [HideInInspector]
    public WeaponScriptableObject weaponData;

    protected virtual void Start()
    {
        currentPierce = weaponData.pierce;
        Destroy(gameObject, weaponData.duration);
    }

    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;

        float dirX = direction.x;
        float dirY = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if (dirX < 0 && dirY == 0) //left
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
        }
        else if (dirX > 0 && dirY == 0) // right
        {
            scale.y = scale.y * -1;
        }
        else if (dirX == 0 && dirY < 0) // down
        {
            scale.y = scale.y * -1;
        }
        else if (dirX == 0 && dirY > 0) // up
        {
            scale.y = scale.y * -1;
        }
        else if (dirX > 0 && dirY > 0) // right up
        {
            rotation.z = 0f;
        }
        else if (dirX > 0 && dirY < 0) // right down
        {
            rotation.z = -90f;
        }
        else if (dirX < 0 && dirY > 0) // left up
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = -90f;
        }
        else if (dirX < 0 && dirY < 0) // left down
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = 0f;
        }
        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation);
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            EnemyController enemy = col.GetComponent<EnemyController>();
            enemy.TakeDamage(weaponData.damage);
            ReducePierce();
        }
    }

    void ReducePierce()
    {
        currentPierce--;
        if (currentPierce <= 0)
        {
            Destroy(gameObject);
        }
    }
}
