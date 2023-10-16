using System.Collections;
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

            StartCoroutine(ShootProjectile(worldPosition));
        }
    }

    IEnumerator ShootProjectile(Vector3 targetPosition)
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        if (projectile != null)
        {
            Vector3 direction = (targetPosition - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
        }

        yield return null;
    }
}
