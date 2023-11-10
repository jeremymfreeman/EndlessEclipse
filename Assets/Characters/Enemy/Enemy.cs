using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Enemy : MonoBehaviour
{
    public static event Action<Enemy> OnEnemyKilled;
    public static int enemyCount = 0; // static variable to track enemy count
    public float speed = 3f;
    [SerializeField] float health, maxHealth = 100f;
    private Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public AudioSource audioSource;
    public AudioClip damageSound;

    private float timeSinceLastUpdate = 0f;
    private float updateInterval = 30f;
    private float healthIncrease = 75f;
    private float speedIncrease = 0.2f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    private void Update()
    {
        timeSinceLastUpdate += Time.deltaTime;
        if (timeSinceLastUpdate >= updateInterval)
        {
            timeSinceLastUpdate = 0f;
            health += healthIncrease;
            speed += speedIncrease;
        }
    }

    private void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            Vector2 direction = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }
        
        if (rb.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (rb.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    } 


    public void TakeDamage(float damageAmount)
    {
        audioSource.PlayOneShot(damageSound);
        health -= damageAmount;

        if (health <= 0)
        {
            Destroy(gameObject, damageSound.length);
            OnEnemyKilled?.Invoke(this);
            enemyCount++; // increment enemy count when an enemy is destroyed
            Debug.Log(enemyCount); // print enemy count to console

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
