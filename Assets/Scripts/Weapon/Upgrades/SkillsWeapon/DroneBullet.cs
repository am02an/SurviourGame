using UnityEngine;

public class DroneBullet : MonoBehaviour
{
    private float damage;
    private Vector3 moveDir;
    public float speed = 15f;
    public float lifeTime = 4f;

    public void Initialize(Vector3 dir, float dmg)
    {
        moveDir = dir;
        damage = dmg;

        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += moveDir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();

        if (enemy != null && !enemy.IsDead)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
