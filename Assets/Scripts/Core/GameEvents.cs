using System;

public static class GameEvents
{
    // Health changed event
    public static Action<float, float> OnPlayerHealthChanged;
    // Game restart event
    public static Action OnGameRestart;

    // Player death event
    public static Action OnPlayerDied;

    // Player collected gem event
    public static Action<int, int> OnPlayerCollectGem;
    // current gems , gems required

    // Player level up event (optional)
    public static Action OnPlayerLevelUp;

    // Health pickup collected
    public static Action<float> OnPlayerCollectHealth;
    // parameter = health percentage increase

    // Coins pickup collected
    public static Action<int> OnPlayerCollectCoins;
    // parameter = coins amount

    public static Action OnEnemyKilled;

    public static void RaiseEnemyKilled()
    {
        OnEnemyKilled?.Invoke();
    }
    public static void RaiseHealthChanged(float current, float max)
    {
        OnPlayerHealthChanged?.Invoke(current, max);
    }
    public static void RaiseGameRestart()
    {
        OnGameRestart?.Invoke();
    }

    public static void RaisePlayerDied()
    {
        OnPlayerDied?.Invoke();
    }

    public static void RaisePlayerCollectGem(int current, int required)
    {
        OnPlayerCollectGem?.Invoke(current, required);
    }

    public static void RaisePlayerLevelUp()
    {
        OnPlayerLevelUp?.Invoke();
    }
    public static void RaisePlayerCollectHealth(float percentage)
    {
        OnPlayerCollectHealth?.Invoke(percentage);
    }

    public static void RaisePlayerCollectCoins(int amount)
    {
        OnPlayerCollectCoins?.Invoke(amount);
    }
}
