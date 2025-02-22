using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The kart
    public Vector3 offset = new Vector3(0, 3, -5); // Set this to be behind
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        // Calculate the camera position in local space relative to the target's rotation
        Vector3 desiredPosition = target.position + target.rotation * offset;

        // Smooth movement
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Make the camera look at the kart
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
