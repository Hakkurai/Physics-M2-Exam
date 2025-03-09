using UnityEngine;

public class ItemBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log("Player collided with Item Box!");

            PlayerBoost playerBoost = other.GetComponent<PlayerBoost>();
            if (playerBoost != null)
            {
                playerBoost.EnableBoost();
            }

            Destroy(gameObject); 
            Debug.Log("Item Box Destroyed!");
        }
    }
}
