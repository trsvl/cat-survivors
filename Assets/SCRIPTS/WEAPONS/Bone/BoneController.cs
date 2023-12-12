using UnityEngine;
using UnityEngine.UIElements;

public class BoneController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
    protected override void Attack()
    {
        base.Attack();


        GameObject bone = Instantiate(weaponData.prefab, transform.position, transform.rotation);

      //  GameObject bone = Instantiate(weaponData.prefab, transform.position, transform.rotation);

        //  bone.transform.position = transform.position;
        //  bone.GetComponent<Rigidbody2D>().velocity = transform.right * 15f;

    }



}
