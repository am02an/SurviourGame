using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public Camera mainCamera;

    [Header("Spawn Timing")]
    public float spawnInterval = 2f;

    [Header("Spawn Distance")]
    public float spawnDistanceFromCamera = 15f; // outside camera

    [Header("Cluster Settings")]
    public int minClusterSize = 5;
    public int maxClusterSize = 12;
    public float scatterRadius = 3f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnGemCluster), 1f, spawnInterval);
    }

    void SpawnGemCluster()
    {
        Vector3 clusterCenter = GetSpawnPositionOutsideCamera();

        int clusterSize = Random.Range(minClusterSize, maxClusterSize + 1);

        for (int i = 0; i < clusterSize; i++)
        {
            Vector2 scatter = Random.insideUnitCircle * scatterRadius;

            Vector3 spawnPos = clusterCenter + new Vector3(scatter.x, 0f, scatter.y);
            spawnPos.y = 0.5f;

            GemPool.Instance.GetGem(spawnPos);
        }
    }

    Vector3 GetSpawnPositionOutsideCamera()
    {
        Vector3 playerPos = player.position;

        // Random direction around player
        Vector2 randomDir = Random.insideUnitCircle.normalized;

        // Spawn outside camera radius
        Vector3 spawnPos = playerPos + new Vector3(randomDir.x, 0f, randomDir.y) * spawnDistanceFromCamera;

        return spawnPos;
    }
}
