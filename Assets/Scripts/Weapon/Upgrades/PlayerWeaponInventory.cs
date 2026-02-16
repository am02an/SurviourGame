using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponInventory : MonoBehaviour
{
    public List<WeaponType> ownedWeapons = new();
    public List<PassiveType> ownedPassives = new();

    public bool HasWeapon(WeaponType type)
    {
        return ownedWeapons.Contains(type);
    }

    public bool HasPassive(PassiveType type)
    {
        return ownedPassives.Contains(type);
    }
}
