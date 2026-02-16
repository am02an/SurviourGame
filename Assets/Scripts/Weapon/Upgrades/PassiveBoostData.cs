using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Passive Boost Data")]
public class PassiveBoostData : ScriptableObject
{
    public PassiveType passiveType;
    public string passiveName;
    public Sprite icon;

    [Header("Buff Values")]
    public float damageMultiplier;
    public float cooldownReduction;
    public float projectileSpeedMultiplier;
    public float explosionRadiusMultiplier;
    public float durationMultiplier;

    public float maxHPBonus;
    public float moveSpeedBonus;
    public float regenBonus;
    public float pickupRangeBonus;
    public float damageReduction;
}
