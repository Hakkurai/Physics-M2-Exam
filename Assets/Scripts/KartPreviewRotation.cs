using UnityEngine;

public class RotateKart : MonoBehaviour
{
    public float rotationSpeed = 30f; 

    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
