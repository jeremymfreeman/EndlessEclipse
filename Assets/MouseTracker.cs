using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracker : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = -mainCamera.transform.position.z;
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Vector3 direction = (worldPosition - transform.position).normalized;
            projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
        }
    }
}

