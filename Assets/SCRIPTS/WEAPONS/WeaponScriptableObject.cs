using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "ScriptableObjects/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    public GameObject prefab;
    public float damage;
    public float cooldown;
    public float speed;
    public int pierce;
    public int level;
    public float duration;
}
