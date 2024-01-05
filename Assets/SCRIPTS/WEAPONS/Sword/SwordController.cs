using UnityEngine;

public class SwordController : WeaponController
{
    private float dirXFirstSword;
    public float DirXFirstSword { get { return dirXFirstSword; } }
    PlayerMovement playerMovement;

    protected override void Start()
    {
        base.Start();
        playerMovement = FindObjectOfType<PlayerMovement>();

        if (catName == catNames[3])
        {
            weaponData.level += 1;
            SkillsWeaponsManager skillsWeaponsManager = FindObjectOfType<SkillsWeaponsManager>();
            skillsWeaponsManager.EmptyImages[0].sprite = weaponData.prefab.GetComponent<SpriteRenderer>().sprite;
        }
    }
    protected override void Update()
    {
        base.Update();
        TriggerNTimes(2, 2, 0.3f);
        TriggerNTimes(3, 2, 0.3f);
        TriggerNTimes(4, 3, 0.3f);
        TriggerNTimes(5, 3, 0.3f);
    }
    protected override void Attack()
    {
        base.Attack();

        if (count == 0)
        {
            dirXFirstSword = playerMovement.LastVector.x;
        }
        if (prevLvl != weaponData.level)
        {
            prevLvl = weaponData.level;
            ModifyData(lvl: 3, damage: 1.5f, cooldown: 3.5f);
            ModifyData(lvl: 4, damage: 1.5f, cooldown: 3.5f);
            ModifyData(lvl: 5, damage: 2f, cooldown: 3f);
        }
        GameObject sword = Instantiate(weaponData.prefab);
        sword.name = "sword" + count;
        count++;
    }
}
