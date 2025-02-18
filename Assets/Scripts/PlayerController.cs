using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 9f;
    private Vector3 movementDirection;
    private Rigidbody2D rb;
  
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ProcessPlayerInputs();
    }

    private void FixedUpdate() {
        MovePlayer();
    }

    // Decide the movement direction based on player inputs
    private void ProcessPlayerInputs(){
        
        float horizontalMovement;
        float verticalMovement;
        
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
     
        movementDirection = new Vector3(horizontalMovement, verticalMovement).normalized;
    }

    // Apply the movement in direction & with playerSpeed
    private void MovePlayer() {
        
        rb.linearVelocity = movementDirection*playerSpeed;
    }
}
