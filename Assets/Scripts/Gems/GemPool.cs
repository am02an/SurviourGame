using System.Collections.Generic;
using UnityEngine;

public class GemPool : MonoBehaviour
{
    public static GemPool Instance;

    public GameObject gemPrefab;
    public int poolSize = 20;

    private Queue<GameObject> gemPool = new Queue<GameObject>();

    void Awake()
    {
        Instance = this;
        InitializePool();
    }

    private void OnEnable()
    {
        GameEvents.OnGameRestart += ResetAllGems;
    }

    private void OnDisable()
    {
        GameEvents.OnGameRestart -= ResetAllGems;
    }

    void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject gem = Instantiate(gemPrefab);
            gem.SetActive(false);
            gemPool.Enqueue(gem);
        }
    }

    public GameObject GetGem(Vector3 position)
    {
        GameObject gem;

        if (gemPool.Count > 0)
            gem = gemPool.Dequeue();
        else
            gem = Instantiate(gemPrefab);

        position.y += 0.05f;

        gem.transform.position = position;
        gem.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        gem.SetActive(true);

        return gem;
    }

    public void ReturnGem(GameObject gem)
    {
        gem.SetActive(false);
        gemPool.Enqueue(gem);
    }

    void ResetAllGems()
    {
        GameObject[] activeGems = GameObject.FindGameObjectsWithTag("Gem");

        foreach (GameObject gem in activeGems)
        {
            if (gem.activeInHierarchy)
            {
                ReturnGem(gem);
            }
        }
    }
}
