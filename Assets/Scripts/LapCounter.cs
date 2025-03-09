using UnityEngine;
using UnityEngine.SceneManagement;  
using TMPro;

public class LapCounter : MonoBehaviour
{
    public TMP_Text lapText;        
    public int totalLaps = 3;       
    private int currentLap = 0;     

    private void Start()
    {
        UpdateLapText();  
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("EndLap"))
        {
            if (currentLap < totalLaps)
            {
                currentLap++;        
                UpdateLapText();     
            }

            if (currentLap >= totalLaps)
            {
                GoToWinScene();      
            }
        }
    }

    private void UpdateLapText()
    {
        lapText.text = "Lap: " + currentLap + "/" + totalLaps;
    }

    private void GoToWinScene()
    {
        SceneManager.LoadScene("WinScene");  
    }
}
