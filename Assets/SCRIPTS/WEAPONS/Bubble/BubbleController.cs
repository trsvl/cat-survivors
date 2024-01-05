using UnityEngine;

public class BubbleController : WeaponController
{
    protected override void Start()
    {
        base.Start();

        if (catName == catNames[1])
        {
            weaponData.level += 1;
            SkillsWeaponsManager skillsWeaponsManager = FindObjectOfType<SkillsWeaponsManager>();
            skillsWeaponsManager.EmptyImages[0].sprite = weaponData.prefab.GetComponent<SpriteRenderer>().sprite;
        }
    }
    protected override void Attack()
    {
        ModifyData(lvl: 2, duration: 2.5f);
        ModifyData(lvl: 3, damage: 1f, duration: 3);
        ModifyData(lvl: 4, damage: 1.5f, duration: 3.5f);
        ModifyData(lvl: 5, damage: 2f, duration: 4f);
        base.Attack();
        Instantiate(weaponData.prefab);
    }
}
