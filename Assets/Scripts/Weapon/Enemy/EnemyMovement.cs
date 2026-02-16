using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyStatsHandler stats;
    private Transform player;

    private Vector3 chaseOffset;

    [SerializeField] float separationRadius = 1.2f;
    [SerializeField] float separationForce = 2f;

    private float attackTimer;

    public void Initialize(EnemyStatsHandler statHandler)
    {
        stats = statHandler;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        chaseOffset = Random.insideUnitSphere * 1.5f;
        chaseOffset.y = 0;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        // ================= WALKER =================
        if (stats.EnemyType == EnemyType.Walker)
        {
            MoveTowardsPlayer();
        }

        // ================= SHOOTER =================
        else if (stats.EnemyType == EnemyType.Shooter)
        {
            if (distance > stats.AttackRange)
            {
                // Chase player
                MoveTowardsPlayer();
            }
            else
            {
                // Stop & Shoot
                HandleShooting();
            }
        }
    }

    // ================= MOVE =================
    void MoveTowardsPlayer()
    {
        Vector3 dirToPlayer =
            (player.position - transform.position).normalized;

        Vector3 separation = GetSeparationForce();

        Vector3 finalDir = (dirToPlayer + separation).normalized;

        transform.position += finalDir * stats.MoveSpeed * Time.deltaTime;
    }

    // ================= SHOOT =================
    void HandleShooting()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= stats.AttackCooldown)
        {
            attackTimer = 0f;
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        if (stats.bulletPrefab == null) return;

        Vector3 dir =
            (player.position - transform.position).normalized;

        // Offset spawn position
        Vector3 spawnPos = transform.position + dir * 1.2f;

        // Rotation with extra 90 degree X tilt
        Quaternion rot =
            Quaternion.LookRotation(dir) *
            Quaternion.Euler(90f, 0f, 0f);

        GameObject bullet = Instantiate(
            stats.bulletPrefab,
            spawnPos,
            rot
        );

        EnemyBullet bulletScript = bullet.GetComponent<EnemyBullet>();
        if (bulletScript != null)
        {
            bulletScript.damage = stats.Damage;
        }

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = dir * stats.bulletSpeed;
        }
    }



    // ================= SEPARATION =================
    Vector3 GetSeparationForce()
    {
        Collider[] neighbours =
            Physics.OverlapSphere(transform.position, separationRadius);

        Vector3 force = Vector3.zero;

        foreach (var col in neighbours)
        {
            if (col.gameObject == gameObject) continue;
            if (col.GetComponent<EnemyMovement>() == null) continue;

            Vector3 diff = transform.position - col.transform.position;
            force += diff.normalized / diff.magnitude;
        }

        return force * separationForce;
    }
}
