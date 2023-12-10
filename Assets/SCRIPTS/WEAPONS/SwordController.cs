using UnityEngine;
using UnityEngine.UIElements;

public class SwordController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }
    protected override void Attack()
    {
        base.Attack();
        GameObject sword = Instantiate(weaponData.prefab);
        sword.transform.position = transform.position; //asign pos of weapon to player
    }
}
