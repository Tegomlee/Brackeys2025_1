using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 2f;
    private Vector3 movementDirection;
    private Rigidbody2D rb;
    private Animator animator;
    public bool phonetrigger;

    private bool isGrounded = false;

    private SpriteRenderer spriteRenderer;
  
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        ProcessPlayerInputs();
    }

    private void FixedUpdate() {
        if(isGrounded){
            MovePlayer();
            // Change player animation when moving
            animator.SetFloat("xVelocity", Math.Abs(rb.linearVelocity.x));
        }
        
    }

    // Decide the movement direction based on player inputs
    private void ProcessPlayerInputs(){
        
        float horizontalMovement;
        // float verticalMovement;
        
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        // verticalMovement = Input.GetAxisRaw("Vertical");
     
        movementDirection = new Vector3(horizontalMovement, 0).normalized;
    }

    // Apply the movement in direction & with playerSpeed
    private void MovePlayer() {
        FlipPlayer(movementDirection.x);
        rb.linearVelocity = movementDirection*playerSpeed;
    }

    private void FlipPlayer(float xDirection){
        if(xDirection < 0){
            spriteRenderer.flipX = false;
        }else if(xDirection > 0){
            spriteRenderer.flipX = true;
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Exclude the player layer to avoid self collision trigger
        if(collision.gameObject.layer != 3){
            isGrounded = true;
        }
        if(collision.gameObject.CompareTag("phonetrigger") == true)
        {
            phonetrigger = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 3  && collision.gameObject.CompareTag("floor") == true)
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // Exclude the player layer to avoid self collision trigger
        if(collision.gameObject.layer != 3 && collision.gameObject.CompareTag("floor") == true)
        {
            isGrounded = false;
        }
        if (collision.gameObject.CompareTag("phonetrigger") == true)
        {
            phonetrigger = false;
        }
    }
}
