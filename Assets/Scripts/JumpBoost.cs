using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    public float boostForce = 15f;  // Boost jump strength

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the kart has the "Player" tag
        {
            KartController kart = other.GetComponent<KartController>();
            if (kart != null)
            {
                kart.Jump(boostForce);
            }
        }
    }
}
