using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public float projectileLifetime = 5f;
    public float projectileSpeed = 10f;
    public int projectileDamage = 10;

    private Rigidbody2D rb;

    private bool isDestroyed = false;

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
            Destroy(gameObject);
        }
        else if (other.CompareTag("Tilemap"))
        {
            isDestroyed = true;
            Destroy(gameObject);
        }
        else if (other.CompareTag("Collisions"))
        {
            isDestroyed = true;
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player") && other.gameObject != gameObject.transform.parent.gameObject)
        {
            // Add code to execute when colliding with other players
        }
        else
        {
            // Add code to execute when colliding with other objects
        }
    }
}
