using UnityEngine;
using System.Collections.Generic;

public class DroneBWeapon : BaseWeapon
{
    public GameObject dronePrefab;
    public int droneCount = 2;

    private List<GameObject> drones = new();
    Vector3 offset = new Vector3(0, 3, 0);
    public override void Initialize(ActiveWeaponData weaponData, Transform playerTransform)
    {
        base.Initialize(weaponData, playerTransform);
        dronePrefab = weaponData.weaponPrefab;

        SpawnDrones();
    }

    void SpawnDrones()
    {
        for (int i = 0; i < droneCount; i++)
        {
            GameObject drone = Instantiate(dronePrefab, player.position+offset, Quaternion.identity, player);
            drone.transform.SetParent(transform);
            drones.Add(drone);
        }
    }

    protected override void Attack()
    {
        EnemyHealth[] enemies = FindObjectsOfType<EnemyHealth>();

        foreach (var enemy in enemies)
        {
            if (enemy.IsDead) continue;

            float dist = Vector3.Distance(player.position, enemy.transform.position);

            if (dist <= data.range)
                enemy.TakeDamage(data.damage);
        }
    }
}
