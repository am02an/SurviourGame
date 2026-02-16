using UnityEngine;

public class PlayerSkillHandler : MonoBehaviour
{
    PlayerStatsHandler stats;
    PlayerCombat combat;

    public void Initialize(PlayerStatsHandler statHandler, PlayerCombat combatHandler)
    {
        stats = statHandler;
        combat = combatHandler;
    }

    public void ApplySkill(SkillData skill)
    {
        switch (skill.effectType)
        {
            case SkillEffectType.AddWeapon:
                combat.AddWeapon(skill.weaponToAdd);
                break;

            case SkillEffectType.StatBoost:
                stats.AddModifier(new StatModifier(skill.statValue, skill.statType));
                break;
        }
    }
}
