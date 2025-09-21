using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class UprightReset : MonoBehaviour
{
    [Header("Reset Settings")]
    public KeyCode resetKey = KeyCode.R;      // Key to press
    public float uprightSmoothness = 5f;      // How fast to upright (higher = snappier)

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(resetKey))
        {
            ResetUpright();
        }
    }

    void ResetUpright()
    {
        // Freeze physics briefly so it doesn't fight the reset
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Instantly set upright rotation
        Quaternion upright = Quaternion.LookRotation(transform.forward, Vector3.up);
        transform.rotation = upright;
    }
}
