using UnityEngine;

public class WeaponEvolutionManager : MonoBehaviour
{
    public WeaponEvolutionRule[] evolutionRules;
    public PlayerWeaponInventory inventory;

    public WeaponType? TryEvolve(WeaponType weapon)
    {
        foreach (var rule in evolutionRules)
        {
            if (rule.baseWeapon == weapon &&
                inventory.HasPassive(rule.requiredPassive))
            {
                return rule.resultWeapon;
            }
        }

        return null;
    }
}
public enum WeaponType
{
    TypeADrone,
    TypeBDrone,
    SoccerBall,
    Forcefield,
    Guardian,
    RocketLauncher,
    Molotov,
    LightningEmitter,
    LaserLauncher,
    Durian,
    DrillShot,
    RPG,


         Destroyer,
    QuantumBall,
    PressureField,
    FuelBarrel,
    WhistlingArrow,
    SharkmawGun,
    ThunderboltPowerCell
}
public enum PassiveType
{
    AttackBoost,
    AmmoThruster,
    EnergyCube,
    HEFuel,
    BulletproofVest,
    FitnessGuide,
    SportsShoes,
    EnergyDrink,
    Magnet,
    ExoBracer,
    RoninOyoroi,
    None
}
