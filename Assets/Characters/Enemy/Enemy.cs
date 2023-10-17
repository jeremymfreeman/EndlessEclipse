using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Enemy : MonoBehaviour
{
    public static event Action<Enemy> OnEnemyKilled;
    public Transform target;
    public float speed = 3f;
    public float rotateSpeed = 0.0025f;
    private Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    [SerializeField] float health, maxHealth = 100f;
    private int currentHealth;
     public Material flashMaterial;
    private Material defaultMaterial;
    public AudioSource audioSource;
    public AudioClip damageSound;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        defaultMaterial = spriteRenderer.material;
    }


    private void Update()
    {
        if (!target)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    } 


    public void TakeDamage(float damageAmount)
    {
        audioSource.PlayOneShot(damageSound);
        health -= damageAmount;
        StartCoroutine(FlashMaterial());

        if (health <= 0)
        {
            Destroy(gameObject, damageSound.length);
            OnEnemyKilled?.Invoke(this);
        }
    }

    private IEnumerator FlashMaterial()
    {
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(1f);
        spriteRenderer.material = defaultMaterial;
    }


    private void RotateTowardsTarget()
    {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);

        if (targetDirection.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (targetDirection.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void GetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

}