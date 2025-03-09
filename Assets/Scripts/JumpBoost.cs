using UnityEngine;
using System.Collections;

public class JumpBoost : MonoBehaviour
{
    public float boostForce = 15f;  
    public float rotationResetDelay = 0.5f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            KartController kart = other.GetComponent<KartController>();
            if (kart != null)
            {
                kart.Jump(boostForce);
                StartCoroutine(ResetRotationAfterDelay(kart));
            }
        }
    }

    private IEnumerator ResetRotationAfterDelay(KartController kart)
    {
        yield return new WaitForSeconds(rotationResetDelay); 
        Quaternion newRotation = Quaternion.Euler(0, kart.transform.rotation.eulerAngles.y, 0);
        kart.transform.rotation = newRotation;
    }
}
