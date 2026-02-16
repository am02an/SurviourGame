using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour
{
    private EnemyStatsHandler stats;
    private float currentHealth;
    [Header("Health UI")]
    [SerializeField] private GameObject healthUI;
    private Slider healthSlider;

    private SpriteRenderer spriteRenderer;
    private Collider enemyCollider;
    private EnemyMovement movement;
    public bool IsDead { get; private set; }

    void OnEnable()
    {
        IsDead = false;
    }
    private void OnDisable()
    {
        IsDead = true;
    }
    // =============================
    // INITIALIZE
    // =============================
    public void Initialize(EnemyStatsHandler statHandler)
    {
        stats = statHandler;
        currentHealth = stats.MaxHealth;

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        enemyCollider = GetComponent<Collider>();
        movement = GetComponent<EnemyMovement>();

        // Health UI Setup
        if (healthUI != null)
        {
            healthSlider = healthUI.GetComponentInChildren<Slider>();
            healthSlider.value = 1f;
            healthUI.SetActive(true);
        }
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;

        UpdateHealthUI();

        if (currentHealth <= 0f)
            Die();
    }

    void UpdateHealthUI()
    {
        if (healthSlider == null) return;

        healthSlider.value = currentHealth / stats.MaxHealth;
    }

    void Die()
    {
        IsDead = true;
        // Disable gameplay
        if (enemyCollider != null)
            enemyCollider.enabled = false;

        if (movement != null)
            movement.enabled = false;
        SpawnDeathVisual();
        TryDropRewards();
        GameEvents.RaiseEnemyKilled();
        EnemyPoolManager.Instance.ReturnToPool(
           gameObject,
           stats.EnemyPrefab
       );

    }
    void TryDropRewards()
    {
        float yOffset = 1.0f;
        float rewardLifeTime = 5f; // Kitne seconds visible rahe

        Vector3 spawnPos = transform.position + new Vector3(0f, yOffset, 0f);
        Quaternion rot = Quaternion.Euler(90f, 0f, 0f);
        // ===== Coin Drop =====
        if (stats.Coins != null &&
            Random.value <= stats.coinDropChance)
        {
            GameObject coin = Instantiate(
                stats.Coins,
                spawnPos,
                rot
            );

            Destroy(coin, rewardLifeTime);
        }

        // ===== Health Drop =====
        if (stats.Health != null &&
            Random.value <= stats.healthDropChance)
        {
            GameObject health = Instantiate(
                stats.Health,
                spawnPos,
                rot
            );

            Destroy(health, rewardLifeTime);
        }
    }




    void SpawnDeathVisual()
    {
        if (stats.DeathPrefab == null)
            return;

        // Get current rotation
        Quaternion currentRotation = transform.rotation;

        // Apply 90 degrees on X-axis
        Quaternion newRotation = Quaternion.Euler(90f, currentRotation.eulerAngles.y, currentRotation.eulerAngles.z);

        // Instantiate with new rotation
        GameObject corpse = Instantiate(
            stats.DeathPrefab,
            transform.position,
            newRotation
        );

        Vector3 pos = corpse.transform.position;
        pos.y += 0.05f;
        corpse.transform.position = pos;



        var corpseScript = corpse.GetComponent<EnemyCorpse>();

        if (corpseScript != null)
            corpseScript.Initialize(stats.CorpseLifetime);
    }
   
}
