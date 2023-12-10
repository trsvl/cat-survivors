using UnityEngine;

public class Melee : MonoBehaviour
{
    protected Vector3 direction;
    public float destroyAfterSec;
    public WeaponScriptableObject weaponData;


    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSec);
    }


    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            EnemyController enemy = col.GetComponent<EnemyController>();
            enemy.TakeDamage(weaponData.damage);
        }
    }


}
