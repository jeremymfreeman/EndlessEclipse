using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public float projectileLifetime = 3f;
    public float projectileSpeed = 5f;
    public int projectileDamage = 10;

    private Rigidbody2D rb;

    private bool isDestroyed = false;

    void Start()
    {
        // Set the lifetime timer
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, projectileLifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDestroyed)
        {
            return;
        }

        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(projectileDamage);
            }
            isDestroyed = true;
            Destroy(rb.gameObject);
        }
        else if (other.CompareTag("Tilemap"))
        {
            isDestroyed = true;
            Destroy(rb.gameObject);
        }
        else if (other.CompareTag("Collisions"))
        {
            isDestroyed = true;
            Destroy(rb.gameObject);
        }
    }
}

