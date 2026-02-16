using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Data")]
    public EnemyData enemyData;

    [Header("Modules")]
    public EnemyMovement movement;
    public EnemyHealth health;
    public EnemyAttack attack;
    public EnemyStatsHandler stats;

    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        stats.Initialize(enemyData);

        movement.Initialize(stats);
        health.Initialize(stats);
        attack.Initialize(stats);
    }
}
