using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponController : MonoBehaviour
{
    public WeaponScriptableObject weaponData;
    float currentCooldown;

    protected PlayerMovement charMovement;

    public int level = 0;

    protected virtual void Start()
    {
        charMovement = FindObjectOfType<PlayerMovement>();
        currentCooldown = weaponData.cooldown;
       // Destroy(gameObject, lifeTime);
       // GetComponent<Rigidbody2D>().velocity = direction.normalized * speedProjectile;
    }


    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown < 0f)
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        currentCooldown = weaponData.cooldown;
    }



    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {

    //        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

    //        if (enemy != null)
    //        {
    //            Destroy(gameObject);
    //            enemy.TakeDamage(damage);

    //        }
    //    }
    //}




}
