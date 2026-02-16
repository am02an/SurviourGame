using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyStatsHandler stats;
    private Transform player;
    private float cooldownTimer;

    public void Initialize(EnemyStatsHandler statHandler)
    {
        stats = statHandler;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        cooldownTimer -= Time.deltaTime;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= stats.AttackRange && cooldownTimer <= 0)
        {
            AttackPlayer();
            cooldownTimer = stats.AttackCooldown;
        }
    }

    void AttackPlayer()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.TakeDamage(stats.Damage);
    }
}
