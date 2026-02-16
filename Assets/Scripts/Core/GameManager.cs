using UnityEngine;
public enum GameState
{
    Playing,
    Paused,
    GameOver
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState CurrentState;

    private void Awake()
    {
        Instance = this;
    }

    public void SetState(GameState state)
    {
        CurrentState = state;
        Time.timeScale = state == GameState.Paused ? 0 : 1;
    }
}
