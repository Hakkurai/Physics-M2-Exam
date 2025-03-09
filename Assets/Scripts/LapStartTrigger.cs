using UnityEngine;

public class LapStartTrigger : MonoBehaviour
{
    public Timer timerScript; 

    private bool hasStarted = false; 

    private void OnTriggerEnter(Collider other)
    {
        if (!hasStarted && other.CompareTag("Player")) 
        {
            hasStarted = true;
            timerScript.StartTimer(); 
            Debug.Log("Timer Started!");
        }
    }
}
