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
        // Decide the movement direction
        float horizontalMovement;
        float verticalMovement;
        
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
     
        movementDirection = new Vector3(horizontalMovement, verticalMovement).normalized;
    }

    private void FixedUpdate() {
        // Apply the movement in direction & with playerSpeed
        rb.linearVelocity = movementDirection*playerSpeed;
    }
}
