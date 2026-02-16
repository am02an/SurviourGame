using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyData[] enemyTypes;
    public DifficultyCurveData difficultyData;

    [Header("Spawn Settings")]
    public float spawnDistanceFromCamera = 3f;
    public Transform spawnParent;
    private float gameTimer;
    private float spawnTimer;

    private Transform player;
    private Camera mainCamera;

  public  void StartGame()
    {
        GameManager.Instance.SetState(GameState.Playing);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        mainCamera = Camera.main;
        foreach (var enemy in enemyTypes)
        {
            EnemyPoolManager.Instance.InitializePool(enemy.enemyPrefab, 40, spawnParent);
        }
    }

    void Update()
    {
        if (GameManager.Instance.CurrentState != GameState.Playing) return;
        gameTimer += Time.deltaTime;

        float timePercent = gameTimer / difficultyData.maxGameTime;

        float spawnRate = difficultyData.spawnRateCurve.Evaluate(timePercent);

        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            int spawnCount = Mathf.CeilToInt(spawnRate);

            for (int i = 0; i < spawnCount; i++)
            {
                SpawnEnemy();
            }

            spawnTimer = 0.5f; // Fixed tick interval
        }
    }


    void SpawnEnemy()
    {
        EnemyData data ;
        if (Random.value < 0.7f) // 70% chance
        {
            data = enemyTypes[0];
        }
        else
        {
            data = enemyTypes[Random.Range(1, enemyTypes.Length)];
        }
        Vector3 spawnPos = GetSpawnPosition();

        GameObject enemy =
            EnemyPoolManager.Instance.Spawn(data.enemyPrefab, spawnPos, spawnParent);

        enemy.GetComponent<EnemyController>().enemyData = data;
    }

    Vector3 GetSpawnPosition()
    {
        float camHeight = mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;

        float spawnDistanceX = camWidth + spawnDistanceFromCamera;
        float spawnDistanceZ = camHeight + spawnDistanceFromCamera;

        // Pick random side of camera rectangle
        int side = Random.Range(0, 4);

        Vector3 spawnPos = player.position;

        switch (side)
        {
            case 0: // Top
                spawnPos += new Vector3(
                    Random.Range(-spawnDistanceX, spawnDistanceX),
                    0,
                    spawnDistanceZ
                );
                break;

            case 1: // Bottom
                spawnPos += new Vector3(
                    Random.Range(-spawnDistanceX, spawnDistanceX),
                    0,
                    -spawnDistanceZ
                );
                break;

            case 2: // Left
                spawnPos += new Vector3(
                    -spawnDistanceX,
                    0,
                    Random.Range(-spawnDistanceZ, spawnDistanceZ)
                );
                break;

            case 3: // Right
                spawnPos += new Vector3(
                    spawnDistanceX,
                    0,
                    Random.Range(-spawnDistanceZ, spawnDistanceZ)
                );
                break;
        }

        return spawnPos;
    }
}
