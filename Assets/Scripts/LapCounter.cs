using UnityEngine;
using TMPro;

public class LapCounter : MonoBehaviour
{
    public TMP_Text lapText; // Reference to the UI lap counter
    public int totalLaps = 3; // Set total laps for the race
    private int currentLap = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure only the player triggers this
        {
            currentLap++;
            lapText.text = "Lap: " + currentLap + " / " + totalLaps;

            if (currentLap >= totalLaps)
            {
                Debug.Log("Race Finished!");
                // Add race completion logic here (e.g., stop timer, show results, etc.)
            }
        }
    }
}
