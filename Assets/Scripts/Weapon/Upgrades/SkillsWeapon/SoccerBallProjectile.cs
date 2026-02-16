using UnityEngine;

public class SoccerBallProjectile : MonoBehaviour
{
    private float speed;
    private float damage;

    public int maxBounce = 10;
    private int bounceCount = 0;

    private Rigidbody rb;

    public void Initialize(float spd, float dmg)
    {
        speed = spd;
        damage = dmg;

        rb = GetComponent<Rigidbody>();

        Vector3 dir = Random.insideUnitSphere.normalized;
        dir.y = 0;

        rb.linearVelocity = dir * speed;

        Destroy(gameObject, 8f); // lifetime
    }

    // ================= Collision =================
    private void OnCollisionEnter(Collision collision)
    {
        // ---- Enemy Hit ----
        EnemyHealth enemy = collision.collider.GetComponent<EnemyHealth>();

        if (enemy != null && !enemy.IsDead)
        {
            enemy.TakeDamage(damage);
        }

        // ---- Bounce Count ----
        bounceCount++;

        if (bounceCount >= maxBounce)
        {
            Destroy(gameObject);
        }
    }
}
