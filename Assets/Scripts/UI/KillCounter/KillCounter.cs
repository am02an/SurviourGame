using UnityEngine;
using TMPro;

public class KillCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI killText;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private GameObject deathPanel;

    private int totalKills = 0;
    private int totalCoins = 0;

    private void OnEnable()
    {
        GameEvents.OnEnemyKilled += UpdateKillUI;
        GameEvents.OnPlayerCollectCoins += UpdateCoins;
        GameEvents.OnPlayerDied += ShowDeathPanel;
        GameEvents.OnGameRestart += ResetData;
    }

    private void OnDisable()
    {
        GameEvents.OnEnemyKilled -= UpdateKillUI;
        GameEvents.OnPlayerCollectCoins -= UpdateCoins;
        GameEvents.OnPlayerDied -= ShowDeathPanel;
        GameEvents.OnGameRestart -= ResetData;
    }

    void UpdateKillUI()
    {
        totalKills++;
        killText.text = totalKills.ToString();
    }

    void UpdateCoins(int amount)
    {
        totalCoins += amount;
        coinText.text = totalCoins.ToString();
    }

    void ShowDeathPanel()
    {
        deathPanel.SetActive(true);
    }

    void ResetData()
    {
        totalKills = 0;
        totalCoins = 0;

        killText.text = "0";
        coinText.text = "0";

        deathPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
