using UnityEngine;

[CreateAssetMenu(menuName = "Survivor/Enemy Data")]
public class EnemyData : ScriptableObject
{
    [Header("Type")]
    public EnemyType enemyType;
    [Header("Stats")]
    public float maxHealth;
    public float moveSpeed;
    public float damage;
    public float attackRange;
    public float attackCooldown;

    [Header("Rewards")]
    public GameObject coins;
    public GameObject health;
    [Range(0f, 1f)] public float coinDropChance = 0.5f;
    [Range(0f, 1f)] public float healthDropChance = 0.2f;
    [Header("Visual")]
    public GameObject enemyPrefab;
    [Header("Death Visual")]
    public GameObject deathPrefab;
    public float corpseLifetime = 2f;
    [Header("Shooter Settings")]
    public GameObject bulletPrefab;
    public float bulletSpeed;

}
public enum EnemyType
{
    Walker,
    Shooter
}
