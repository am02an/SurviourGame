using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Data")]
    public PlayerData playerData;

    [Header("Modules")]
    public PlayerMovement movement;
    public PlayerStatsHandler stats;
    public PlayerHealth health;
    public PlayerCombat combat;
    public PlayerSkillHandler skills;
    public PlayerVisualHandler visuals;


    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        stats.Initialize(playerData);

        movement.Initialize(stats);
        health.Initialize(stats);
        combat.Initialize(stats);
        skills.Initialize(stats, combat);

        // Starting Weapon
        if (playerData.startingWeapon != null)
            combat.AddWeapon(playerData.startingWeapon);

        // Starting Skills
        foreach (var skill in playerData.startingSkills)
            skills.ApplySkill(skill);
    }

    public void SetMovementInput(Vector3 input)
    {
        movement.SetInput(input);
        visuals.UpdateFacing(input);
    }
}
