using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform weaponParent;

    private PlayerStatsHandler stats;

    // Fast lookup
    private Dictionary<string, WeaponBase> activeWeapons =
        new Dictionary<string, WeaponBase>();

    public void Initialize(PlayerStatsHandler statHandler)
    {
        stats = statHandler;
    }

    public void AddWeapon(WeaponData data)
    {
        if (data == null)
        {
            Debug.LogWarning("WeaponData is NULL");
            return;
        }

        string weaponID = data.weaponID;

        // Upgrade existing weapon
        if (activeWeapons.TryGetValue(weaponID, out WeaponBase existingWeapon))
        {
            existingWeapon.Upgrade();
            return;
        }

        // Spawn new weapon
        SpawnWeapon(data);
    }

    private void SpawnWeapon(WeaponData data)
    {
        GameObject obj = Instantiate(data.weaponPrefab, weaponParent);

        WeaponBase weapon = obj.GetComponent<WeaponBase>();

        if (weapon == null)
        {
            Debug.LogError("WeaponPrefab missing WeaponBase!");
            return;
        }

        weapon.Initialize(data, stats);

        activeWeapons.Add(data.weaponID, weapon);
    }
}
