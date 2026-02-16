using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Active Weapon Data")]
public class ActiveWeaponData : ScriptableObject
{
    public WeaponType weaponType;
    public string weaponName;
    public Sprite icon;
    public GameObject weaponPrefab;

    [Header("Weapon Stats")]
    public float damage;
    public float range;
    public float cooldown;
    public float duration;
    public float projectileSpeed;

    [Header("Evolution")]
    public bool canEvolve;
    public WeaponType evolvedWeapon;
    public PassiveType requiredPassive;
}
