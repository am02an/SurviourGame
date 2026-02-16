using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    List<WeaponBase> activeWeapons = new();

    public Transform weaponParent;

    PlayerStatsHandler stats;

    public void Initialize(PlayerStatsHandler statHandler)
    {
        stats = statHandler;
    }

    public void AddWeapon(WeaponData weaponData)
    {
        var weaponObj = Instantiate(weaponData.weaponPrefab, weaponParent);

        WeaponBase weapon = weaponObj.GetComponent<WeaponBase>();
        weapon.Initialize(weaponData, stats);

        activeWeapons.Add(weapon);
    }
}
