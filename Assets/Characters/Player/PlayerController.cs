using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Vector2 movementInput;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponet<RigidBody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        if(movementInput != Vector2.zero) {
             
        }

    }

    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();


    }
}
