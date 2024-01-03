using UnityEngine;

public class PotatoController : WeaponController
{
    protected override void Start()
    {
        base.Start();
        if (catName == catNames[0])
        {
            weaponData.level += 1;
            SkillsWeaponsManager skillsWeaponsManager = FindObjectOfType<SkillsWeaponsManager>();
            skillsWeaponsManager.emptyImages[0].sprite = weaponData.prefab.GetComponent<SpriteRenderer>().sprite;
        }
    }

    protected override void Update()
    {
        base.Update();
        TriggerNTimes(2, 2, 0.4f);
        TriggerNTimes(3, 2, 0.4f);
        TriggerNTimes(4, 3, 0.3f);
        TriggerNTimes(5, 4, 0.3f);
    }
    protected override void Attack()
    {
        if (prevLvl != weaponData.level)
        {
            prevLvl = weaponData.level;
            ModifyData(lvl: 3, damage: 1.5f, pierce: 2, cooldown: 2.5f);
            ModifyData(lvl: 4, damage: 1.5f, pierce: 2, cooldown: 2.5f);
            ModifyData(lvl: 5, damage: 2f, pierce: 3, cooldown: 2f);
        }
        base.Attack();

        GameObject potato = Instantiate(weaponData.prefab);
        potato.transform.position = transform.position;
        potato.GetComponent<PotatoProjectile>().DirectionChecker(charMovement.lastVector);
        count++;
    }
}
