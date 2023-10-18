using UnityEngine;


public class EnemyDoDamage : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Hi");
        // Code to handle collision goes here
    }
}