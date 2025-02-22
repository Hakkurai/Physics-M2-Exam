using UnityEngine;

public class ItemBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure player collides with the box
        {
            Debug.Log("Player collided with Item Box!");

            PlayerBoost playerBoost = other.GetComponent<PlayerBoost>();
            if (playerBoost != null)
            {
                playerBoost.EnableBoost();
            }

            Destroy(gameObject); // Destroy the item box after pickup
            Debug.Log("Item Box Destroyed!");
        }
    }
}
