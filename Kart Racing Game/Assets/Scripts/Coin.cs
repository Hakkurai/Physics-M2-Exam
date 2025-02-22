using UnityEngine;

public class Coin : MonoBehaviour
{
    public enum CoinType { Bronze, Silver, Gold }
    public CoinType coinType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (coinType)
            {
                case CoinType.Bronze:
                    Debug.Log("Bronze Coin Collected! +10 Points");
                    break;
                case CoinType.Silver:
                    Debug.Log("Silver Coin Collected! Speed Debuff Activated!");
                    break;
                case CoinType.Gold:
                    Debug.Log("Gold Coin Collected! Speed Boost Activated!");
                    break;
            }

            // Use the new Unity recommended method instead of FindObjectOfType
            PrefabSpawner spawner = Object.FindFirstObjectByType<PrefabSpawner>();

            if (spawner != null)
            {
                spawner.CoinCollected();
            }
            else
            {
                Debug.LogError("PrefabSpawner instance not found! Make sure it's active in the scene.");
            }

            Destroy(gameObject);
        }
    }
}
