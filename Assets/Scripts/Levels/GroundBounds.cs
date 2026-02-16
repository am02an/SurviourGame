using UnityEngine;

public class GroundBounds : MonoBehaviour
{
    public static GroundBounds Instance;

    [Header("Manual Ground Size")]
    public Vector2 groundSize = new Vector2(100, 100);

    [Header("Manual Ground Center")]
    public Vector3 groundCenter = Vector3.zero;

    private Bounds bounds;

    void Awake()
    {
        Instance = this;
        CalculateBounds();
    }

    void CalculateBounds()
    {
        bounds = new Bounds(
            groundCenter,
            new Vector3(groundSize.x, 1, groundSize.y)
        );
    }

    // ================= PLAYER CLAMP =================
    public Vector3 ClampPosition(Vector3 position)
    {
        float x = Mathf.Clamp(position.x, bounds.min.x, bounds.max.x);
        float z = Mathf.Clamp(position.z, bounds.min.z, bounds.max.z);

        return new Vector3(x, position.y, z);
    }

    // ================= CAMERA CLAMP =================
    public Vector3 ClampCamera(Vector3 camPos)
    {
        Camera cam = Camera.main;

        float camHalfHeight = cam.orthographicSize;
        float camHalfWidth = camHalfHeight * cam.aspect;

        float x = Mathf.Clamp(camPos.x,
            bounds.min.x + camHalfWidth,
            bounds.max.x - camHalfWidth);

        float z = Mathf.Clamp(camPos.z,
            bounds.min.z + camHalfHeight,
            bounds.max.z - camHalfHeight);

        return new Vector3(x, camPos.y, z);
    }

    void OnDrawGizmos()
    {
        CalculateBounds();

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(bounds.center, bounds.size);
    }
}
