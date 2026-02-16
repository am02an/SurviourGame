using UnityEngine;
using System.Collections.Generic;

public class LightningWeapon : BaseWeapon
{
    [Header("Lightning Settings")]
    public GameObject lightningVFX;
    public float strikeRadius = 10f;
    public int strikeCount = 1;

    public override void Initialize(ActiveWeaponData weaponData, Transform playerTransform)
    {
        base.Initialize(weaponData, playerTransform);

        lightningVFX = weaponData.weaponPrefab;
    }
    protected override void Attack()
    {
        List<EnemyHealth> enemies = GetEnemiesInRange();

        if (enemies.Count == 0)
            return;

        for (int i = 0; i < strikeCount; i++)
        {
            EnemyHealth target =
                enemies[Random.Range(0, enemies.Count)];

            Strike(target);
        }
    }

    // ================= Strike Enemy =================
    void Strike(EnemyHealth enemy)
    {
        if (enemy == null || enemy.IsDead)
            return;
        Vector3 strikePos = GetRandomPositionAroundPlayer();
        // Spawn VFX
        if (lightningVFX != null)
        {
          GameObject lightning=  Instantiate(
                lightningVFX,
                strikePos,
                Quaternion.identity
            );
          
        }

        // Apply Damage
        enemy.TakeDamage(data.damage);
    }

    Vector3 GetRandomPositionAroundPlayer()
    {
        Vector2 random = Random.insideUnitCircle * strikeRadius;

        return player.position + new Vector3(random.x, 2, random.y);
    }

    // ================= Get Enemies =================
    List<EnemyHealth> GetEnemiesInRange()
    {
        EnemyHealth[] allEnemies =
            FindObjectsOfType<EnemyHealth>();

        List<EnemyHealth> validEnemies = new();

        foreach (var enemy in allEnemies)
        {
            if (enemy.IsDead)
                continue;

            float dist = Vector3.Distance(
                player.position,
                enemy.transform.position);

            if (dist <= strikeRadius)
                validEnemies.Add(enemy);
        }

        return validEnemies;
    }
}
