using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public static PrefabSpawner Instance { get; private set; }
    public GameObject[] prefabsToSpawn;
    public float spawnRadius = 3f;

    private int currentIndex = 0;
    private GameObject activeCoin = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (activeCoin == null)
        {
            SpawnPrefab();
        }
    }

    void SpawnPrefab()
    {
        if (prefabsToSpawn.Length == 0)
        {
            Debug.LogWarning("No prefabs assigned to spawn!");
            return;
        }

        Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = new Vector3(transform.position.x + randomOffset.x, transform.position.y, transform.position.z + randomOffset.y);

        activeCoin = Instantiate(prefabsToSpawn[currentIndex], spawnPosition, Quaternion.identity);
        currentIndex = (currentIndex + 1) % prefabsToSpawn.Length;
    }

    public void CoinCollected()
    {
        activeCoin = null; // Reset so a new coin can be spawned
    }
}
