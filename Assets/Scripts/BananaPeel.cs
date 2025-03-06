using UnityEngine;

public class BananaPeel : MonoBehaviour
{
    // Spin-out force and duration
    public float spinOutForce = 500f;
    public float spinOutDuration = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure the kart has the tag "Player"
        {
            KartController kart = other.GetComponent<KartController>();
            if (kart != null)
            {
                kart.SpinOut(spinOutForce, spinOutDuration);
                Destroy(gameObject); // Remove the banana peel after collision
            }
        }
    }
}
