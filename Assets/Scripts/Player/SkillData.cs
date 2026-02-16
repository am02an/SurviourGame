using UnityEngine;

public enum SkillEffectType
{
    AddWeapon,
    StatBoost
}

[CreateAssetMenu(menuName = "Survivor/Skills/Skill")]
public class SkillData : ScriptableObject
{
    public string skillName;
    public SkillEffectType effectType;

    public WeaponData weaponToAdd;

    public StatType statType;
    public float statValue;
}
