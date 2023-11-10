using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int playerMaxHealth = 100;
    public int playerCurrentHealth;
    public Animator animator;
    void Start()
    {
        playerMaxHealth = playerCurrentHealth;
        
    }
    public void PlayerTakeDamage(int damage)
    {

        playerCurrentHealth -= damage;
        if (playerCurrentHealth <= 0)
        {
            animator.SetBool("isDead", true);
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
