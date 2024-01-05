using UnityEngine;

public class PotatoProjectile : Projectile
{
    PotatoController controller;

    void Awake()
    {
        controller = FindObjectOfType<PotatoController>();
        weaponData = controller.WeaponData;
    }
    void Update()
    {
        transform.position += direction * weaponData.speed * Time.deltaTime;
    }
}
