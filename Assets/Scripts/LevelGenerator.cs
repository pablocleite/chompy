using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject foodPrefab;

    [SerializeField]
    private GameObject pillPrefab;

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField, Range(1, 1000)]
    private int foodPiecesCount = 100;
    
    [SerializeField, Range(1, 100)]
    private int pillsCount = 10;

    public float spawnAreaSize = 1.0f; //Size of the level plane

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnFood();
        SpawnPills();
    }

    private void SpawnPills()
    {
        for (int i = 0; i < pillsCount; i++)
        {
            var randomPosition = GetRandomPosition();
            Debug.Log($"Spawning pills at {randomPosition}");

            Instantiate(pillPrefab, randomPosition, Quaternion.identity);
        }
    }

    private void SpawnFood()
    {
        for (int i = 0; i < foodPiecesCount; i++)
        {
            var randomPosition = GetRandomPosition();
            Debug.Log($"Spawning food at {randomPosition}");

            Instantiate(foodPrefab, randomPosition, Quaternion.identity);
        }
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(
            Random.Range(-spawnAreaSize / 2, spawnAreaSize / 2),
            0.02f, // Slightly above the plane
            Random.Range(-spawnAreaSize / 2, spawnAreaSize / 2)
        );
    }

    // Update is called once per frame
    void Update()
    {
    }
}