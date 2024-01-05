using UnityEngine;

public class BoneController : WeaponController
{
    protected override void Start()
    {
        base.Start();

        if (catName == catNames[2])
        {
            weaponData.level += 1;
            SkillsWeaponsManager skillsWeaponsManager = FindObjectOfType<SkillsWeaponsManager>();
            skillsWeaponsManager.EmptyImages[0].sprite = weaponData.prefab.GetComponent<SpriteRenderer>().sprite;
        }
    }
    protected override void Update()
    {
        base.Update();
        TriggerNTimes(2, 2, 0.2f);
        TriggerNTimes(3, 3, 0.2f);
        TriggerNTimes(4, 4, 0.2f);
        TriggerNTimes(5, 5, 0.2f);
    }
    protected override void Attack()
    {
        if (prevLvl != weaponData.level)
        {
            prevLvl = weaponData.level;
            ModifyData(lvl: 3, damage: 1.5f, pierce: 3, cooldown: 3.5f);
            ModifyData(lvl: 4, damage: 1.5f, pierce: 3, cooldown: 3.5f);
            ModifyData(lvl: 5, damage: 2f, pierce: 4, cooldown: 3f);
        }
        base.Attack();
        Instantiate(weaponData.prefab, transform.position, transform.rotation);
        count++;
    }
}
