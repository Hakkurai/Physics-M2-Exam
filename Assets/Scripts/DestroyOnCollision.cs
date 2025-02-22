using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the player has the correct tag
        {
            Destroy(gameObject);
            Debug.Log("Prefab Destroyed by Player Collision!");
        }
    }
}
