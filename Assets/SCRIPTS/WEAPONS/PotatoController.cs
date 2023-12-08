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
}
