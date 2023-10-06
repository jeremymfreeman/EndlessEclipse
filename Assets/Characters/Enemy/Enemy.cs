
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour {
    public Transform target;
    public float speed = 3f;
    public float rotateSpeed = 0.0025f;
    private Rigidbody2D rb;
     SpriteRenderer spriteRenderer;
    public int maxHealth = 100;
    private int currentHealth;


    private void Start() { 
            spriteRenderer = GetComponent<SpriteRenderer>();
            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            currentHealth = maxHealth;
    }


    private void Update () {
        if (!target) {
            GetTarget();
        } else {
            RotateTowardsTarget();
        }
    }

    private void FixedUpdate() {
        rb.velocity = transform.up * speed;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Check if the enemy's health has reached zero or below
        if (currentHealth <= 0)
        {
            Die(); // Implement a Die() method to handle enemy death
        }
    }


        private void RotateTowardsTarget() {
            Vector2 targetDirection = target.position - transform.position;
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);

         if(targetDirection.x < 0) {
                spriteRenderer.flipX = true;
            } else if (targetDirection.x > 0) {
                spriteRenderer.flipX = false;
            }
    }

    private void GetTarget() {
        if (GameObject.FindGameObjectWithTag("Player")) {
          target = GameObject.FindGameObjectWithTag("Player").transform;  
         }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            Destroy(other.gameObject);
            target = null;
        }
    }

     private void Die()
    {
        // Handle enemy death, such as playing death animations, awarding points, etc.
        Destroy(gameObject); // Destroy the enemy GameObject
    }
}