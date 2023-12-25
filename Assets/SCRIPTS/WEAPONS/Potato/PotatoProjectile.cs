using UnityEngine;

public class PotatoProjectile : Projectile
{
    PotatoController controller;

    private void Awake()
    {
        controller = FindObjectOfType<PotatoController>();
        weaponData = controller.weaponData;
    }
    void Update()
    {
        transform.position += direction * weaponData.speed * Time.deltaTime;
    }
}
