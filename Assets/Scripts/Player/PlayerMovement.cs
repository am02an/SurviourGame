using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerStatsHandler stats;
    Vector3 moveInput;

    public void Initialize(PlayerStatsHandler statHandler)
    {
        stats = statHandler;
    }

    public void SetInput(Vector3 input)
    {
        moveInput = input;
    }

    void Update()
    {
        float speed = stats.GetStat(StatType.MoveSpeed);

        transform.Translate(moveInput * speed * Time.deltaTime, Space.World);
        if (GroundBounds.Instance != null)
        {
            transform.position =
                GroundBounds.Instance.ClampPosition(transform.position);
        }
    }
}
