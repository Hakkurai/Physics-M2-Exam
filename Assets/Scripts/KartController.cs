using UnityEngine;
using System.Collections; // Needed for Coroutine

public class KartController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10f;
    public float turnSpeed = 100f;
    public float gravity = 20f;
    public float jumpForce = 10f;
    public Transform kartModel;

    private Vector3 moveDirection;
    private float defaultSpeed;
    private bool isBoosted = false;

    void Start()
    {
        defaultSpeed = speed; // Store the original speed
    }

    void Update()
    {
        // Get input
        float moveInput = -Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        // Move forward/backward
        Vector3 forwardMovement = transform.forward * moveInput * speed;

        // Apply gravity
        if (!controller.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        else
        {
            moveDirection.y = -0.1f; // Keeps it on the ground
        }

        // New Drift Mechanic (Replace Jump)
if (Input.GetKey(KeyCode.Space)) // Hold space to drift
{
    speed = defaultSpeed * 1.2f; // Small speed boost while drifting
    turnSpeed = 150f; // Increase turning ability
}
else
{
    speed = defaultSpeed;
    turnSpeed = 100f;
}

        // Move the kart
        controller.Move((forwardMovement + moveDirection) * Time.deltaTime);

        // Rotate the kart
        transform.Rotate(0, turnInput * turnSpeed * Time.deltaTime, 0);

        // Adjust kart tilt on slopes
        AdjustTilt();
    }

    public void Jump(float boost)
    {
        moveDirection.y = boost;
    }

    void AdjustTilt()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 1f))
        {
            Quaternion targetRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            kartModel.rotation = Quaternion.Lerp(kartModel.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }

    // ✅ Speed Boost Logic
    public void ApplySpeedBoost(float boost, float duration)
    {
        if (!isBoosted)
        {
            isBoosted = true;
            speed += boost;
            StartCoroutine(ResetSpeed(duration));
        }
    }

    private IEnumerator ResetSpeed(float duration)
    {
        yield return new WaitForSeconds(duration);
        speed = defaultSpeed; // Reset speed after boost
        isBoosted = false;
    }
}
