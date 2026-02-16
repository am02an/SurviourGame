using UnityEngine;
using System.Collections.Generic;

public class MolotovWeapon : BaseWeapon
{
    public GameObject molotovPrefab;
    public float throwRadius = 8f;
    public float burnDuration = 3f;

    public override void Initialize(ActiveWeaponData weaponData, Transform playerTransform)
    {
        base.Initialize(weaponData, playerTransform);
        molotovPrefab = weaponData.weaponPrefab;
    }

    protected override void Attack()
    {
        Vector3 targetPos = GetRandomPositionAroundPlayer();

        if (molotovPrefab != null)
        {
            GameObject molotov = Instantiate(molotovPrefab, targetPos, Quaternion.identity);
            molotov.transform.SetParent(transform);
            Destroy(molotov, burnDuration);
        }

        DamageEnemies(targetPos);
    }

    Vector3 GetRandomPositionAroundPlayer()
    {
        Vector2 random = Random.insideUnitCircle * throwRadius;
        return player.position + new Vector3(random.x, 0, random.y);
    }

    void DamageEnemies(Vector3 pos)
    {
        EnemyHealth[] enemies = FindObjectsOfType<EnemyHealth>();

        foreach (var enemy in enemies)
        {
            if (enemy.IsDead) continue;

            float dist = Vector3.Distance(pos, enemy.transform.position);

            if (dist <= data.range)
                enemy.TakeDamage(data.damage);
        }
    }
}
