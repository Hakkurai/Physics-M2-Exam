using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // 🟢 Import for scene management

public class LapCounter : MonoBehaviour
{
    public TMP_Text lapText;                  // Reference to the UI lap counter
    public int totalLaps = 3;                 // Set total laps for the race
    private int currentLap = 0;

    public Transform[] checkpoints;           // 🟢 Array of checkpoints
    private int nextCheckpointIndex = 0;      // 🟢 Tracks next checkpoint
    private bool lapInProgress = false;       // 🟢 Ensures lap is valid

    public Collider finishLine;               // 🟢 Finish line collider

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 🟢 Checkpoint Detection
            if (nextCheckpointIndex < checkpoints.Length)
            {
                Transform nextCheckpoint = checkpoints[nextCheckpointIndex];
                float distanceToCheckpoint = Vector3.Distance(other.transform.position, nextCheckpoint.position);

                if (distanceToCheckpoint < 200f)  // 🟢 Increased detection radius
                {
                    nextCheckpointIndex++;       // 🟢 Move to next checkpoint
                    lapInProgress = true;        // 🟢 Valid lap in progress
                    Debug.Log("Checkpoint Reached: " + nextCheckpointIndex);
                }
                else
                {
                    Debug.Log("Too far from checkpoint: " + distanceToCheckpoint);
                }
            }
        }
    }

    // 🟢 Separate method to handle finish line
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && other == finishLine && lapInProgress && nextCheckpointIndex >= checkpoints.Length)
        {
            Debug.Log("Finish line reached!");   // 🟢 Log for finish line detection
            currentLap++;
            nextCheckpointIndex = 0;             // 🟢 Reset checkpoint index
            lapInProgress = false;               // 🟢 Reset lap status
            lapText.SetText("Lap: " + currentLap + " / " + totalLaps);  // 🟢 Force update UI text
            Debug.Log("Lap Completed! Current Lap: " + currentLap);

            if (currentLap >= totalLaps)
            {
                Debug.Log("Race Finished!");
                LoadWinScene();                  // 🟢 Load win scene
            }
        }
    }

    // 🟢 Load the win scene
    private void LoadWinScene()
    {
        SceneManager.LoadScene("WinScene");
    }
}
