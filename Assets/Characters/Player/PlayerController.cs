using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;

    Vector2 movementInput;
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate() {
        //If movement input is not 0, try to move
        if(movementInput != Vector2.zero) {
          bool success = TryMove(movementInput);

            if(!success) {
                success = TryMove(new Vector2(movementInput.x, 0));

                if(!success) {
                    success = TryMove(new Vector2(0, movementInput.y));
                }
            }

                animator.SetBool("isMoving", success); 
            } else {
                animator.SetBool("isMoving", false);
            }
        }

    private bool TryMove(Vector2 direction) {
        // Check for potnetial collisions
           int count = rb.Cast(
            direction, // X and Y values between -1 and 1 represent the direction from the body to look for collisions
            movementFilter, // The settings that determine where a collision can occour on such as layers to collide with
            castCollisions, // List of collisions to store the found collisiosn into after the Cast is finsihed
            moveSpeed * Time.fixedDeltaTime + collisionOffset); // tThe amount to cast equal to the movementplus an offset

        if(count == 0) {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true; 
        } else {
            return false;
        }
    }



    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }
}
