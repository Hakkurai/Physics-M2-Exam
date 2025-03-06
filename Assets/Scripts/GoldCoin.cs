using UnityEngine;

public class GoldCoin : MonoBehaviour
{
    public int pointValue = 10;  // Points awarded for collecting this coin (adjust if needed)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Make sure the player has the "Player" tag
        {
            PointsManager.Instance.AddPoints(pointValue);  // Add points using the singleton
            Destroy(gameObject);  // Remove the coin
        }
    }
}
