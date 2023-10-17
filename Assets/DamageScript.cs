using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageScript : MonoBehaviour
{
    public int projectileDamage = 10;
    public float projectileLifetime = 3f;
    public float projectileSpeed = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        // Set the lifetime timer
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, projectileLifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(projectileDamage);
            Debug.Log("Hit!");
        }
    }
}
