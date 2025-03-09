using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float boostAmount = 30f; 
    public float boostDuration = 2f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            KartController kart = other.GetComponent<KartController>();
            if (kart != null)
            {
                kart.ApplySpeedBoost(boostAmount, boostDuration);
            }
        }
    }
}
