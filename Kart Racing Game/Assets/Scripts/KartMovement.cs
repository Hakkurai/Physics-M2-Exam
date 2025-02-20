using UnityEngine;

public class KartController : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 50f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckDistance = 0.5f;
    public float slopeAdjustmentSpeed = 5f;
    public float maxTiltAngle = 30f;
    public float antiTiltForce = 10f; // Keeps front from tilting too much
    public float stabilizationForce = 500f; // Keeps kart from tipping sideways

    private Rigidbody rb;
    private bool isGrounded;
    private Vector3 normalVector = Vector3.up;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -0.5f, -0.3f); // Moves mass slightly backward to prevent front heaviness
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        rb.angularDamping = 15f; // Slows down unstable rotations
    }

    void FixedUpdate()
    {
        GroundCheck();
        AdjustKartRotation();
        MoveKart();
        ApplyStabilizationForces();
        ResetRotationIfFlipped();
    }

    void GroundCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(groundCheck.position, Vector3.down, out hit, groundCheckDistance, groundLayer))
        {
            isGrounded = true;
            normalVector = hit.normal;
        }
        else
        {
            isGrounded = false;
        }
    }

    void AdjustKartRotation()
    {
        if (isGrounded)
        {
            Quaternion targetRotation = Quaternion.FromToRotation(transform.up, normalVector) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * slopeAdjustmentSpeed);
        }
    }

    void MoveKart()
    {
        float moveInput = Input.GetAxis("Vertical") * speed;
        float turnInput = Input.GetAxis("Horizontal") * turnSpeed * Time.fixedDeltaTime;

        rb.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
        transform.Rotate(0, turnInput, 0);

        if (isGrounded)
        {
            rb.AddForce(-transform.up * antiTiltForce, ForceMode.Acceleration);
        }
    }

    void ApplyStabilizationForces()
    {
        if (isGrounded)
        {
            Vector3 localVelocity = transform.InverseTransformDirection(rb.linearVelocity);

            // Apply force to stabilize sideways tilting
            rb.AddForce(-transform.right * localVelocity.x * stabilizationForce * Time.fixedDeltaTime, ForceMode.Force);
        }
    }

    void ResetRotationIfFlipped()
    {
        Vector3 localEuler = transform.localEulerAngles;
        if (localEuler.x > maxTiltAngle && localEuler.x < 360 - maxTiltAngle)
        {
            localEuler.x = 0;
        }
        if (localEuler.z > maxTiltAngle && localEuler.z < 360 - maxTiltAngle)
        {
            localEuler.z = 0;
        }
        transform.localEulerAngles = localEuler;
    }
}
