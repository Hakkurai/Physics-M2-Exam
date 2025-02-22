using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float boostAmount = 30f; // How much speed to add
    public float boostDuration = 2f; // How long the boost lasts

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure it's the kart
        {
            KartController kart = other.GetComponent<KartController>();
            if (kart != null)
            {
                kart.ApplySpeedBoost(boostAmount, boostDuration);
            }
        }
    }
}
