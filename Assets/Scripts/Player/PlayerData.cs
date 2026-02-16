using UnityEngine;

[CreateAssetMenu(menuName = "Survivor/Player/PlayerData")]
public class PlayerData : ScriptableObject
{
    [Header("Base Stats")]
    public float maxHP = 100;
    public float moveSpeed = 5;
    public float baseDamage = 10;
    public float attackSpeed = 1;

    [Header("Starting Loadout")]
    public WeaponData startingWeapon;

    [Header("Starting Skills")]
    public SkillData[] startingSkills;
}
