using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    // Define coin types
    public enum CoinType { Bronze, Gold, Silver }
    public CoinType coinType;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colliders entered trigger: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player picked up a " + coinType + " coin!");
            KartController kart = other.GetComponent<KartController>();

            if (kart != null)
            {
                switch (coinType)
                {
                    case CoinType.Bronze:
                        Debug.Log("Bronze coin collected: +10 points");
                        kart.AddPoints(10);
                        break;

                    case CoinType.Gold:
                        Debug.Log("Gold coin collected: Speed boost activated");
                        kart.ApplyGoldBoost();
                        break;

                    case CoinType.Silver:
                        Debug.Log("Silver coin collected: Speed debuff applied");
                        kart.ApplySilverDebuff();
                        break;

                    default:
                        Debug.LogError("Coin Type not recognized!");
                        break;
                }
            }

            Debug.Log("Destroying " + gameObject.name);
            Destroy(gameObject);
        }
    }
}
