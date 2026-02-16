using UnityEngine;

public class PlayerGemCollector : MonoBehaviour
{
    [Header("Gem Level Settings")]
    [SerializeField] private int gemsToLevelUp = 10;
    [SerializeField] private int levelUpIncrease = 5;
    [SerializeField] private GameObject skilGameobject;

    private int currentGems = 0;

    [Header("Reward Settings")]
    [SerializeField] private int coinValue = 20;
    [SerializeField] private float healthPercent = 0.5f;

    private int baseGemsToLevelUp; // store original value

    private void Awake()
    {
        baseGemsToLevelUp = gemsToLevelUp;
    }

    private void OnEnable()
    {
        GameEvents.OnGameRestart += ResetData;
    }

    private void OnDisable()
    {
        GameEvents.OnGameRestart -= ResetData; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gem"))
        {
            CollectGem(other.gameObject);
        }
        else if (other.CompareTag("Coin"))
        {
            CollectCoin(other.gameObject);
        }
        else if (other.CompareTag("Health"))
        {
            CollectHealth(other.gameObject);
        }
    }

    // ================= GEM =================

    void CollectGem(GameObject gem)
    {
        currentGems++;

        GameEvents.RaisePlayerCollectGem(currentGems, gemsToLevelUp);

        GemPool.Instance.ReturnGem(gem);

        //if (currentGems >= gemsToLevelUp)
        //{
        //    skilGameobject.SetActive(true);
        //    Time.timeScale = 0f;
        //}
    }

    // ================= COIN =================

    void CollectCoin(GameObject coin)
    {
        GameEvents.RaisePlayerCollectCoins(coinValue);
        Destroy(coin);
    }

    // ================= HEALTH =================

    void CollectHealth(GameObject healthPickup)
    {
        GameEvents.RaisePlayerCollectHealth(healthPercent);
        Destroy(healthPickup);
    }

    // ================= LEVEL UP =================

    void LevelUp()
    {
        currentGems = 0;
        gemsToLevelUp += levelUpIncrease;

        GameEvents.RaisePlayerLevelUp();
    }

    // ================= RESET =================

    void ResetData()
    {
        currentGems = 0;
        gemsToLevelUp = baseGemsToLevelUp;

        // Hide skill panel
        skilGameobject.SetActive(false);

        // Reset time just in case restart is triggered from level up pause
        Time.timeScale = 1f;

        // Refresh UI
        GameEvents.RaisePlayerCollectGem(currentGems, gemsToLevelUp);
    }
}
