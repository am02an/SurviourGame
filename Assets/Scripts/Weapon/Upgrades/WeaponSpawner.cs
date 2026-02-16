using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public Transform player;

    public List<ActiveWeaponData> weaponDatabase;

    private Dictionary<WeaponType, BaseWeapon> activeWeapons = new();

    public void SpawnWeapon(WeaponType type)
    {
        if (activeWeapons.ContainsKey(type))
            return;

        ActiveWeaponData data =
            weaponDatabase.Find(w => w.weaponType == type);

        if (data == null)
        {
            Debug.LogError("Weapon data not found");
            return;
        }

        GameObject weaponGO = new GameObject(type.ToString());
        weaponGO.transform.SetParent(player);

        BaseWeapon weapon = weaponGO.AddComponent(GetWeaponClass(type)) as BaseWeapon;

        weapon.Initialize(data, player);

        activeWeapons.Add(type, weapon);
    }

    System.Type GetWeaponClass(WeaponType type)
    {
        return type switch
        {
            WeaponType.LightningEmitter => typeof(LightningWeapon),
            WeaponType.Molotov => typeof(MolotovWeapon),
            WeaponType.SoccerBall => typeof(SoccerBallWeapon),
            WeaponType.TypeADrone => typeof(DroneAWeapon),
            WeaponType.TypeBDrone => typeof(DroneBWeapon),
            _ => typeof(LightningWeapon)
        };
    }
}
