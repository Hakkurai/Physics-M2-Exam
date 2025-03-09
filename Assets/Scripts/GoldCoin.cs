using UnityEngine;

public class GoldCoin : MonoBehaviour
{
    public int pointValue = 10;  

    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))  
    {
        PointsManager.Instance.AddPoints(pointValue);  
        AudioManager.Instance.PlaySFX(AudioManager.Instance.coinSFX); 
        Destroy(gameObject);  
    }
}

}
