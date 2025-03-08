using UnityEngine;

public class GoldCoin : MonoBehaviour
{
    public int pointValue = 10;  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  
        {
            PointsManager.Instance.AddPoints(pointValue);  
            Destroy(gameObject);  
        }
    }
}
