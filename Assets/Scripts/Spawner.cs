using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs; // Drag your 3 prefabs here in Inspector
    public int spawnCount = 3;
    public Vector3 spawnAreaSize = new Vector3(5, 1, 5); // Adjust as needed

    void Start()
    {
        SpawnPrefabs();
    }

    void SpawnPrefabs()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            if (prefabs.Length > 0)
            {
                GameObject prefabToSpawn = prefabs[Random.Range(0, prefabs.Length)];
                Vector3 spawnPos = transform.position + new Vector3(
                    Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                    Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
                    Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
                );

                Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
            }
        }
    }
}
