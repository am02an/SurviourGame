using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolManager : MonoBehaviour
{
    public static EnemyPoolManager Instance;

    private Dictionary<GameObject, Queue<GameObject>> poolDict =
        new Dictionary<GameObject, Queue<GameObject>>();

    void Awake()
    {
        Instance = this;
    }
    private void OnEnable()
    {
        GameEvents.OnGameRestart += ResetAllPools;
    }
    private void OnDisable()
    {
        GameEvents.OnGameRestart += ResetAllPools;
    }
    // ===============================
    // PREWARM POOL
    // ===============================
    public void InitializePool(GameObject prefab, int count,Transform spawnParent)
    {
        if (!poolDict.ContainsKey(prefab))
            poolDict[prefab] = new Queue<GameObject>();

        Queue<GameObject> pool = poolDict[prefab];

        for (int i = 0; i < count; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            obj.transform.SetParent(spawnParent);
            pool.Enqueue(obj);
        }
    }

    // ===============================
    // SPAWN
    // ===============================
    public GameObject Spawn(GameObject prefab, Vector3 pos,Transform spawnParent)
    {
        if (!poolDict.ContainsKey(prefab))
            poolDict[prefab] = new Queue<GameObject>();

        Queue<GameObject> pool = poolDict[prefab];

        GameObject obj;

        if (pool.Count > 0)
        {
            obj = pool.Dequeue();
            obj.SetActive(true);
        }
        else
        {
            // Auto expand pool
            obj = Instantiate(prefab,spawnParent);
        }

        pos.y += 0.05f;
        obj.transform.position = pos;

        return obj;
    }

    // ===============================
    // RETURN
    // ===============================
    public void ReturnToPool(GameObject obj, GameObject prefab)
    {
        obj.SetActive(false);

        if (!poolDict.ContainsKey(prefab))
            poolDict[prefab] = new Queue<GameObject>();

        poolDict[prefab].Enqueue(obj);
    }
    public void ResetAllPools()
    {
        foreach (var pool in poolDict.Values)
        {
            foreach (var obj in pool)
            {
                if (obj != null)
                {
                    obj.SetActive(false);
                }
            }
        }

        // Also find active enemies in scene and return them
        EnemyHealth[] activeEnemies = FindObjectsOfType<EnemyHealth>();

        foreach (var enemy in activeEnemies)
        {
            enemy.gameObject.SetActive(false);
        }
    }

}
