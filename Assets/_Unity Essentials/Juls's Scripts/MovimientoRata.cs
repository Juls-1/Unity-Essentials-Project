using UnityEngine;

// Controls player movement and rotation.
public class MovimientoRata : MonoBehaviour
{
    public float speed = 2.0f; // Set player's movement speed.
    public float rotationSpeed = 120.0f; // Set player's rotation speed.
    public float fuerzaSalto = 10.0f;
    public float impulso = 0.05f;

    private Rigidbody rb; // Reference to player's Rigidbody.

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Access player's Rigidbody.

    }

    // Update is called once per frame

    void Update()
    {
        
        if (Input.GetButton("Jump"))
        {
            //Debug.log("Salto");
            rb.AddForce(transform.forward * impulso, ForceMode.Impulse);
            //rb.AddForce(transform.forward * fuerzaSalto);
            //rb.AddForce(impulso, 0, 0, ForceMode.Impulse);
        }
    }

    // Handle physics-based movement and rotation.
    private void FixedUpdate()
    {
        // Move player based on vertical input.
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = transform.up * moveVertical * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position - movement);

        // Rotate player based on horizontal input.
        float turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, 0f, turn);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}