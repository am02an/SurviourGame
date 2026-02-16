using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    private Transform target;
    private float damage;

    public float speed = 10f;
    [Header("Lifetime")]
    public float lifeTime = 5f;
    private float lifeTimer;

    public void Initialize(Transform targetEnemy, float dmg)
    {
        target = targetEnemy;
        damage = dmg;

        lifeTimer = lifeTime;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = (target.position - transform.position).normalized;

        transform.position += dir * speed * Time.deltaTime;
        Vector3 rot = transform.eulerAngles;
        transform.eulerAngles = new Vector3(90f, rot.y, rot.z);
        HandleLifetime();
    }
    void HandleLifetime()
    {
        lifeTimer -= Time.deltaTime;

        if (lifeTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyHealth enemy))
        {
            Debug.Log("Destory");
            Destroy(gameObject);
            enemy.TakeDamage(damage);
        }
    }
}
