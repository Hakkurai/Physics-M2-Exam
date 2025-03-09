using UnityEngine;

public class PlayerBoost : MonoBehaviour
{
    public float normalSpeed = 10f; 
    public float boostedSpeed = 20f; 
    public float boostDuration = 5f; 
    private bool hasBoost = false;
    private bool isBoosting = false;
    private float boostEndTime = 0f;

    private void Update()
    {
        if (hasBoost && Input.GetKeyDown(KeyCode.LeftShift) && !isBoosting)
        {
            ActivateBoost();
        }

        if (isBoosting && Time.time >= boostEndTime)
        {
            DeactivateBoost();
        }
    }

    public void EnableBoost()
    {
        hasBoost = true;
        Debug.Log("Player has picked up a Speed Boost!");
    }

    private void ActivateBoost()
    {
        isBoosting = true;
        hasBoost = false; 
        boostEndTime = Time.time + boostDuration;
        GetComponent<KartController>().speed = boostedSpeed; 

        Debug.Log("Speed Boost Activated!");
    }

    private void DeactivateBoost()
    {
        isBoosting = false;
        GetComponent<KartController>().speed = normalSpeed; 

        Debug.Log("Speed Boost Ended!");
    }
}
