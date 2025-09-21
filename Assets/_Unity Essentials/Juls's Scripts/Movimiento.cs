using UnityEngine;

// Controls player movement and rotation.
public class Movimiento : MonoBehaviour
{
    public float speed = 2.0f; // Set player's movement speed.
    public float rotationSpeed = 120.0f; // Set player's rotation speed.
    public float jumpForce = 5f;          // Force applied upwards
    public float jumpCooldown = 1f;

    private Rigidbody rb; // Reference to player's Rigidbody.
    private float lastJumpTime;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Access player's Rigidbody.
        lastJumpTime = -jumpCooldown;
        rb.freezeRotation = true;
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetButton("Jump") && Time.time >= lastJumpTime + jumpCooldown)
        {
            Jump();

        }
    }

    // Handle physics-based movement and rotation.
    private void FixedUpdate()
    {
        // Move player based on vertical input.
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * moveVertical * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        // Rotate player based on horizontal input.
        float turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    void Jump()
    {
        // Reset any downward velocity for consistent jump feel
        Vector3 velocity = rb.velocity;
        if (velocity.y < 0)
            velocity.y = 0;

        rb.velocity = velocity;

        // Apply force in the global up direction
        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);

        // Store jump time
        lastJumpTime = Time.time;
    }

}