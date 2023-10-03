using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timeToLiveBullets = 2f;

    void Start()
    {
        Destroy(gameObject, timeToLiveBullets);;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Collisions")
        {
            Object.Destroy(gameObject);
        }
}
}

