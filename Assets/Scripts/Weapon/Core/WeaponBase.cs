using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    protected WeaponData weaponData;
    protected PlayerStatsHandler stats;

    protected float fireTimer;
    protected float currentDamage;
    protected float currentFireRate;

    public virtual void Initialize(WeaponData data, PlayerStatsHandler statHandler)
    {
        weaponData = data;
        stats = statHandler;
        currentDamage = weaponData.baseDamage;
        currentFireRate = weaponData.fireRate;

    }

    protected virtual void Update()
    {
        fireTimer -= Time.deltaTime;

        if (fireTimer <= 0)
        {
            TryFire();
            fireTimer = GetFireRate();
        }
        OnWeaponUpdate();
    }

    protected abstract void TryFire();

    protected virtual float GetFireRate()
    {
        float attackSpeed = stats.GetStat(StatType.AttackSpeed);
        return weaponData.fireRate / attackSpeed;
    }
    protected virtual void OnWeaponUpdate() { }

    // =============================
    //  UPGRADE SYSTEM
    // =============================
    public virtual void Upgrade()
    {
       // level++;

        ApplyUpgradeStats();

        OnUpgrade();

        Debug.Log($"{weaponData.weaponName} Upgraded To Level");
    }

    // =============================
    // STAT SCALING LOGIC
    // =============================
    protected virtual void ApplyUpgradeStats()
    {
        // Default scaling (can override in child weapon)

        // Example scaling:
        // Damage increases 20% per level
        // FireRate increases 10%

        currentDamage *= 1.2f;
        currentFireRate *= 0.9f;


    }

    // =============================
    // CHILD WEAPON CUSTOM LOGIC
    // =============================
    protected virtual void OnUpgrade() { }
}
