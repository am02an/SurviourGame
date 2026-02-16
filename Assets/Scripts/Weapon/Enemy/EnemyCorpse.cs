using UnityEngine;

public class EnemyCorpse : MonoBehaviour
{
    public void Initialize(float lifetime)
    {
        Destroy(gameObject, lifetime);
    }
}
