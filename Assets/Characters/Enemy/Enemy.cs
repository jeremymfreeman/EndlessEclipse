using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Enemy : MonoBehaviour
{
    public static event Action<Enemy> OnEnemyKilled;
    public float speed = 3f;
    [SerializeField] float health, maxHealth = 100f;
    private Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public AudioSource audioSource;
    public AudioClip damageSound;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }


    private void Update()
    {
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
