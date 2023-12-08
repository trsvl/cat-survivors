using UnityEngine;
using UnityEngine.UIElements;

public class PotatoController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }
   
    protected override void Attack()
    {
        base.Attack();
        GameObject potato = Instantiate(weaponData.prefab);
        potato.transform.position = transform.position; //asign pos of weapon to player
        potato.GetComponent<PotatoProjectile>().DirectionChecker(charMovement.lastVector);
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {

    //        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

    //        if (enemy != null)
    //        {
    //            Destroy(weaponData.prefab);
    //            enemy.TakeDamage(weaponData.damage);

    //        }
    //    }
    //}

}
