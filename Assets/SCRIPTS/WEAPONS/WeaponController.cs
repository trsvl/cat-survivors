using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public WeaponScriptableObject weapon;
    [HideInInspector]
    public WeaponScriptableObject weaponData;
    float currentCooldown;
    [HideInInspector]
    public int prevLvl;
    [HideInInspector]
    public int count = 0;
    private SkillsWeaponsManager weaponsManager;
    [HideInInspector]
    public bool nextTrigger = false;
    [HideInInspector]
    public float timer = 0f;
    protected PlayerMovement charMovement;
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
        if (weaponData.level == lvl && nextTrigger)
        {
            timer += Time.deltaTime;

            if (timer >= time && count < n)
            {
                Attack();
                timer = 0f;
                nextTrigger = false;
            }
        }
    }
}
