using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoProjectile : Projectile
{
    protected override void Start()
    {
        base.Start();
    }
    void Update()
    {
        transform.position += direction * weaponData.speed * Time.deltaTime;
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);
    }



}
