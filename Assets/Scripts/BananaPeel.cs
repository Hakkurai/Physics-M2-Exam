using UnityEngine;

public class BananaPeel : MonoBehaviour
{
    public float spinOutForce = 500f;
    public float spinOutDuration = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            KartController kart = other.GetComponent<KartController>();
            if (kart != null)
            {
                AudioManager.Instance.PlaySFX(AudioManager.Instance.bananaSFX); 
                kart.SpinOut(spinOutForce, spinOutDuration);
                Destroy(gameObject);
            }
        }
    }

}
