using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Evolution Rule")]
public class WeaponEvolutionRule : ScriptableObject
{
    public WeaponType baseWeapon;
    public PassiveType requiredPassive;
    public WeaponType resultWeapon;
}
