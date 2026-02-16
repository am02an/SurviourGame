using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerStatsHandler stats;

    private float currentHealth;
    private float maxHealth;

    private void OnEnable()
    {
        GameEvents.OnPlayerCollectHealth += Heal;
        GameEvents.OnGameRestart += ResetPlayer;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerCollectHealth -= Heal;
        GameEvents.OnGameRestart -= ResetPlayer;
    }
   

    void ResetPlayer()
    {
        currentHealth = maxHealth;
    }

    public void Initialize(PlayerStatsHandler statHandler)
    {
        stats = statHandler;

        maxHealth = stats.GetStat(StatType.MaxHP);
        currentHealth = maxHealth;

        // Fire initial UI update
        GameEvents.RaiseHealthChanged(currentHealth, maxHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        GameEvents.RaiseHealthChanged(currentHealth, maxHealth);

        if (currentHealth <= 0)
            Die();
    }

    public void Heal(float amount)
    {
        Debug.Log("Herling"+amount);
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        GameEvents.RaiseHealthChanged(currentHealth, maxHealth);
    }

    void Die()
    {
        GameManager.Instance.SetState(GameState.GameOver);
        GameEvents.RaisePlayerDied();
        Debug.Log("Player Died");

        StartCoroutine(RestartAfterDelay());
    }
    IEnumerator RestartAfterDelay()
    {
        yield return new WaitForSeconds(3f);

        // Hide death panel (if controlled globally, event listener will handle)
        GameEvents.RaiseGameRestart();
        GameManager.Instance.SetState(GameState.Playing);
    }

}
