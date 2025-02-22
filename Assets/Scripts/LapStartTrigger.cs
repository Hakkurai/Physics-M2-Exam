using UnityEngine;

public class LapStartTrigger : MonoBehaviour
{
    public Timer timerScript; // Reference to the Timer script

    private bool hasStarted = false; // Ensure the timer starts only once

    private void OnTriggerEnter(Collider other)
    {
        if (!hasStarted && other.CompareTag("Player")) // Check if player collides
        {
            hasStarted = true;
            timerScript.StartTimer(); // Call the StartTimer() method from Timer script
            Debug.Log("Timer Started!");
        }
    }
}
