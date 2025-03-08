using UnityEngine;
using System.Collections;

public class JumpBoost : MonoBehaviour
{
    public float boostForce = 15f;  // Boost jump strength
    public float rotationResetDelay = 0.5f; // Delay before resetting rotation

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the kart has the "Player" tag
        {
            KartController kart = other.GetComponent<KartController>();
            if (kart != null)
            {
                kart.Jump(boostForce);
                StartCoroutine(ResetRotationAfterDelay(kart));
            }
        }
    }

    private IEnumerator ResetRotationAfterDelay(KartController kart)
    {
        yield return new WaitForSeconds(rotationResetDelay); // Wait before resetting
        Quaternion newRotation = Quaternion.Euler(0, kart.transform.rotation.eulerAngles.y, 0);
        kart.transform.rotation = newRotation;
    }
}
