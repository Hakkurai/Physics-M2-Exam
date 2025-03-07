using UnityEngine;
using UnityEngine.SceneManagement;  // Import for scene management
using TMPro;

public class LapCounter : MonoBehaviour
{
    public TMP_Text lapText;        // Reference to the TMP text component
    public int totalLaps = 3;       // Total number of laps
    private int currentLap = 0;     // Track current lap

    private void Start()
    {
        UpdateLapText();  // Initialize lap text
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the collider
        if (other.CompareTag("EndLap"))
        {
            if (currentLap < totalLaps)
            {
                currentLap++;        // Increment lap
                UpdateLapText();     // Update UI
            }

            // Check if all laps are completed
            if (currentLap >= totalLaps)
            {
                GoToWinScene();      // Load WinScene
            }
        }
    }

    private void UpdateLapText()
    {
        lapText.text = "Lap: " + currentLap + "/" + totalLaps;
    }

    private void GoToWinScene()
    {
        SceneManager.LoadScene("WinScene");  // Change to WinScene
    }
}
