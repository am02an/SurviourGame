using UnityEngine;

public class PlayerVisualHandler : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void UpdateFacing(Vector3 moveInput)
    {
        if (moveInput.x < 0.01f)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput.x > -0.01f)
        {
            spriteRenderer.flipX = true;
        }
    }
}
