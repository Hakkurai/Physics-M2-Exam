using UnityEngine;
using TMPro;

public class KartManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint; // Assign in Inspector
    [SerializeField] private GameObject[] kartPrefabs; // Assign all 3 kart prefabs
    [SerializeField] private TMP_Text lapCounterText; // Assign LapCounter UI Text in Inspector

    private void Start()
    {
        int selectedKart = PlayerPrefs.GetInt("SelectedKart", 0); // Default to first kart
        GameObject spawnedKart = Instantiate(kartPrefabs[selectedKart], spawnPoint.position, spawnPoint.rotation);

        // Assign the spawned kart to the camera
        CameraFollow cameraFollow = FindObjectOfType<CameraFollow>();
        if (cameraFollow != null)
        {
            cameraFollow.target = spawnedKart.transform;
        }

        // Find and assign LapCounter text dynamically
        LapCounter lapCounter = spawnedKart.GetComponent<LapCounter>();
        if (lapCounter != null && lapCounterText != null)
        {
            lapCounter.lapText = lapCounterText;
        }
    }
}
