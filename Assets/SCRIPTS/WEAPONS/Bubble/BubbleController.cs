using UnityEngine;
using UnityEngine.UIElements;

public class BubbleController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }
    protected override void Attack()
    {
        base.Attack();
        GameObject bubble = Instantiate(weaponData.prefab);
      //  bubble.transform.position = transform.position; //asign pos of weapon to player
    }
}
