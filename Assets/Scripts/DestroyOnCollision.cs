using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Destroy(gameObject);
            Debug.Log("Prefab Destroyed by Player Collision!");
        }
    }
}
