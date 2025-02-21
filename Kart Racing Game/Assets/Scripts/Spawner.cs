using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabsToSpawn; // Drag & drop your 3 prefabs here
    public float spawnDelay = 2f; // Delay between spawns
    public int spawnCount = 3; // Number of times to spawn
    public float spawnRange = 2f; // Random offset range to avoid overlapping

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private System.Collections.IEnumerator SpawnObjects()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            SpawnPrefab();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void SpawnPrefab()
    {
        if (prefabsToSpawn.Length == 0)
        {
            Debug.LogError("No prefabs assigned to the spawner!");
            return;
        }

        int randomIndex = Random.Range(0, prefabsToSpawn.Length);
        GameObject selectedPrefab = prefabsToSpawn[randomIndex];

        // Generate a random spawn offset
        Vector3 randomOffset = new Vector3(
            Random.Range(-spawnRange, spawnRange), // X offset
            0, // Y stays the same (adjust if needed)
            Random.Range(-spawnRange, spawnRange) // Z offset
        );

        // New spawn position
        Vector3 spawnPosition = transform.position + randomOffset;

        Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
    }
}
