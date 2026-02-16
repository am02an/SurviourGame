using System.Collections.Generic;
using UnityEngine;
public enum StatType
{
    MaxHP,
    Damage,
    MoveSpeed,
    AttackSpeed
}

public class PlayerStatsHandler : MonoBehaviour
{
    private Dictionary<StatType, float> baseStats = new();
    private List<StatModifier> modifiers = new();

    public void Initialize(PlayerData data)
    {
        baseStats[StatType.MaxHP] = data.maxHP;
        baseStats[StatType.MoveSpeed] = data.moveSpeed;
        baseStats[StatType.Damage] = data.baseDamage;
        baseStats[StatType.AttackSpeed] = data.attackSpeed;
    }

    public void AddModifier(StatModifier mod)
    {
        modifiers.Add(mod);
    }

    public float GetStat(StatType type)
    {
        float value = baseStats[type];

        foreach (var mod in modifiers)
        {
            if (mod.Type == type)
                value += mod.Value;
        }

        return value;
    }
}
public class StatModifier
{
    public float Value;
    public StatType Type;

    public StatModifier(float value, StatType type)
    {
        Value = value;
        Type = type;
    }
}

