using UnityEngine;
using TMPro;

public class KartManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint; 
    [SerializeField] private GameObject[] kartPrefabs; 
    [SerializeField] private TMP_Text lapCounterText; 

    private void Start()
    {
        int selectedKart = PlayerPrefs.GetInt("SelectedKart", 0); 
        GameObject spawnedKart = Instantiate(kartPrefabs[selectedKart], spawnPoint.position, spawnPoint.rotation);

        CameraFollow cameraFollow = FindObjectOfType<CameraFollow>();
        if (cameraFollow != null)
        {
            cameraFollow.target = spawnedKart.transform;
        }

        LapCounter lapCounter = spawnedKart.GetComponent<LapCounter>();
        if (lapCounter != null && lapCounterText != null)
        {
            lapCounter.lapText = lapCounterText;
        }
    }
}
