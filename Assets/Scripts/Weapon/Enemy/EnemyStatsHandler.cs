using UnityEngine;

public class EnemyStatsHandler : MonoBehaviour
{
    private EnemyData data;

    public void Initialize(EnemyData enemyData)
    {
        data = enemyData;
    }
    public EnemyType EnemyType => data.enemyType;
    public float MoveSpeed => data.moveSpeed;
    public float Damage => data.damage;
    public float AttackRange => data.attackRange;
    public float AttackCooldown => data.attackCooldown;
    public float MaxHealth => data.maxHealth;
    public GameObject DeathPrefab => data.deathPrefab;
    public float CorpseLifetime => data.corpseLifetime;
    public GameObject EnemyPrefab => data.enemyPrefab;
    public GameObject bulletPrefab => data.bulletPrefab;
    public float bulletSpeed => data.bulletSpeed;
    public GameObject Coins => data.coins;
    public GameObject Health => data.health;
    public float coinDropChance => data.coinDropChance;
    public float healthDropChance => data.healthDropChance;
}
