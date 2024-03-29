using System.Collections.Generic;
using UnityEngine;
using static SelectCatManager;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private WeaponScriptableObject weapon;
    protected WeaponScriptableObject weaponData;
    public WeaponScriptableObject WeaponData { get { return weaponData; } }
    float currentCooldown;
    protected int prevLvl;
    protected int count = 0;
    private SkillsWeaponsManager weaponsManager;
    float timer = 0f;
    protected PlayerMovement charMovement;
    protected string catName;
    protected List<string> catNames;

    protected virtual void Awake()
    {
        if (weapon != null)
        {
            weaponsManager = FindObjectOfType<SkillsWeaponsManager>();
            weaponData = ScriptableObject.Instantiate(weapon);
            weaponsManager.weapons.Add(weaponData);
        }
    }
    protected virtual void Start()
    {
        catName = PassData.catName;
        catNames = PassData.catNames;

        charMovement = FindObjectOfType<PlayerMovement>();
        currentCooldown = weaponData.cooldown;
        prevLvl = weaponData.level;
    }
    protected virtual void Update()
    {
        if (weaponData.level > 0)
        {
            currentCooldown -= Time.deltaTime;
            if (currentCooldown < 0f)
            {
                count = 0;
                Attack();
            }
        }
    }
    protected virtual void Attack()
    {
        currentCooldown = weaponData.cooldown;
    }
    protected virtual void ModifyData(int lvl, float? damage = null, int? pierce = null, float? cooldown = null, float? duration = null)
    {
        if (weaponData.level == lvl)
        {
            weaponData.damage = damage ?? weaponData.damage;
            weaponData.pierce = pierce ?? weaponData.pierce;
            weaponData.cooldown = cooldown ?? weaponData.cooldown;
            weaponData.duration = duration ?? weaponData.duration;
        }
    }
    protected virtual void TriggerNTimes(int lvl, int n, float time)
    {
        if (weaponData.level == lvl && count < n)
        {
            timer += Time.deltaTime;

            if (timer >= time)
            {
                timer = 0f;
                Attack();
            }
        }
    }
}
