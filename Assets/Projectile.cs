using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;

    void Update()
    {
        // Move the projectile forward
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check for collision with an enemy or other objects
        if (other.CompareTag("Enemy"))
        {
            // Deal damage to the enemy
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            
            // Destroy the projectile on collision
            Destroy(gameObject);
        }
        else
        {
            // Destroy the projectile if it hits anything else
            Destroy(gameObject);
        }
    }
}
