using UnityEngine;

public class ProjectileBase : WeaponBase
{
    protected override void TryFire()
    {
        Transform target = FindNearestEnemy();

        if (target == null)
            return;

        FireProjectile(target);
    }

    void FireProjectile(Transform target)
    {
        GameObject proj =
            Instantiate(weaponData.projectilePrefab, transform.position, Quaternion.identity);

        proj.GetComponent<ProjectileWeapon>()
            .Initialize(target, weaponData.baseDamage);
    }

    Transform FindNearestEnemy()
    {
        EnemyController[] enemies = FindObjectsOfType<EnemyController>();

        Transform closest = null;
        float minDist = weaponData.range;
        foreach (var enemy in enemies)
        {
        EnemyHealth health = enemy.GetComponent<EnemyHealth>();
            if (health != null && health.IsDead)
                continue;
            float dist = Vector3.Distance(transform.position, enemy.transform.position);

            if (dist < minDist)
            {
                minDist = dist;
                closest = enemy.transform;
            }
        }

        return closest;
    }
}
