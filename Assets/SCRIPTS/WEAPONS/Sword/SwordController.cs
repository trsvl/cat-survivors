using UnityEngine;
using UnityEngine.UIElements;

public class SwordController : WeaponController
{
    [HideInInspector]
    public float dirXFirstSword;
    PlayerMovement playerMovement;
    
    protected override void Start()
    {
        base.Start();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }
    protected override void Update()
    {
        base.Update();
        TriggerNTimes(2, 2, 0.3f);
        TriggerNTimes(3, 2, 0.3f);
        TriggerNTimes(4, 3, 0.3f);
        TriggerNTimes(5, 3, 0.3f);
        nextTrigger = true;
    }
    protected override void Attack()
    {
        base.Attack();
        if (count == 0)
        {
            dirXFirstSword = playerMovement.lastVector.x;
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
