using System;
using UnityEngine;
using CodeMonkey.Utils;

public class PlayerAimWeapon : MonoBehaviour
{
    public event EventHandler<OnShootEventArgs> OnShoot;
    public class OnShootEventArgs : EventArgs
    {
        public Vector3 gunEndPointPosition;
        public Vector3 shootPosition;
    }

    public GameObject gunEndPoint; // Reference to the GunEndPoint Position GameObject

    private Transform aimTransform;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
    }

    private void Update()
    {
        HandleAiming();
        HandleShooting();
    }

    private void HandleAiming()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        // Rotate the GunEndPoint Position to match the aiming direction
        gunEndPoint.transform.eulerAngles = new Vector3(0, 0, angle);

        Vector3 aimLocalScale = Vector3.one;
        if (angle > 90 || angle < -90)
        {
            aimLocalScale.x = -1;
        }
        else
        {
            aimLocalScale.x = +1;
        }
        aimTransform.localScale = aimLocalScale;
    }

    private void HandleShooting()
    {
        Debug.Log("HandleShooting called!"); // Add this line
    // ... The rest of your shooting logic .
    
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

            OnShoot?.Invoke(this, new OnShootEventArgs
            {
                gunEndPointPosition = gunEndPoint.transform.position, // Use GunEndPoint Position
                shootPosition = mousePosition,
            });

            if (Input.GetMouseButtonDown(0))
    {
        Debug.Log("Left mouse button clicked.");
        // ... The rest of your shooting logic ...
    }
}
        }
    }

    

