using UnityEngine;

public class PlayerCameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetPos = target.position + offset;

        if (GroundBounds.Instance != null)
        {
            targetPos = GroundBounds.Instance.ClampCamera(targetPos);
        }

        transform.position = targetPos;
    }
}
