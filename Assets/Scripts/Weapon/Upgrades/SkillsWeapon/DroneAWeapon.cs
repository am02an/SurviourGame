using UnityEngine;

public class DroneAWeapon : BaseWeapon
{
    public GameObject dronePrefab;
    public GameObject bulletPrefab;

    private GameObject spawnedDrone;

    public int bulletsPerShot = 3;
    public float scatterAngle = 30f;
    public float fireOffset = 1f;

    public override void Initialize(ActiveWeaponData weaponData, Transform playerTransform)
    {
        base.Initialize(weaponData, playerTransform);

        dronePrefab = weaponData.weaponPrefab;

        spawnedDrone = Instantiate(
            dronePrefab,
            player.position,
            Quaternion.identity,
            player);
    }

    protected override void Attack()
    {
        if (spawnedDrone == null || bulletPrefab == null) return;

        EnemyHealth target = GetNearestEnemy();

        if (target == null) return;

        Vector3 baseDir =
            (target.transform.position - spawnedDrone.transform.position).normalized;

        ShootScatter(baseDir);
    }

    void ShootScatter(Vector3 baseDir)
    {
        int bulletCount = Random.Range(3, 6); // 3 to 5 bullets

        for (int i = 0; i < bulletCount; i++)
        {
            float angle = Random.Range(-scatterAngle, scatterAngle);

            Vector3 dir = Quaternion.Euler(0, angle, 0) * baseDir;

            GameObject bullet = Instantiate(
                bulletPrefab,
                spawnedDrone.transform.position + dir * fireOffset,
                Quaternion.LookRotation(dir)
            );

            DroneBullet bulletScript = bullet.GetComponent<DroneBullet>();

            if (bulletScript != null)
            {
                bulletScript.Initialize(dir, data.damage);
            }
        }
    }

    EnemyHealth GetNearestEnemy()
    {
        EnemyHealth[] enemies = FindObjectsOfType<EnemyHealth>();

        EnemyHealth nearest = null;
        float minDist = Mathf.Infinity;

        foreach (var enemy in enemies)
        {
            if (enemy.IsDead) continue;

            float dist = Vector3.Distance(
                spawnedDrone.transform.position,
                enemy.transform.position);

            if (dist < minDist)
            {
                minDist = dist;
                nearest = enemy;
            }
        }

        return nearest;
    }
}
