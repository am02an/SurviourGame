using UnityEngine;

[CreateAssetMenu(menuName = "Survivor/Weapon/WeaponData")]
public class WeaponData : ScriptableObject
{
    public string weaponID;
    public string weaponName;

    public GameObject weaponPrefab;
    public GameObject projectilePrefab;

    public float baseDamage = 10f;
    public float fireRate = 1f;
    public float range = 5f;
    public float projectileSpeed = 8f;

    public int maxLevel = 5;
}
