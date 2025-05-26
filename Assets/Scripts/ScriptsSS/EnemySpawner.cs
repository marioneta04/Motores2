using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float spawnInterval = 2f;
    public float spawnRangeX = 8f;
    public float spawnZ = 20f;

    public float intervalDecreaseRate = 0.1f; // Cuánto se reduce
    public float decreaseEverySeconds = 10f;  // Cada cuántos segundos
    public float minSpawnInterval = 0.5f;     // Límite mínimo

    private float timer = 0f;
    private float difficultyTimer = 0f;

    void Update()
    {
        // Spawneo
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }

        // Aumento de dificultad
        difficultyTimer += Time.deltaTime;
        if (difficultyTimer >= decreaseEverySeconds)
        {
            spawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - intervalDecreaseRate);
            difficultyTimer = 0f;
        }
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = new Vector3(randomX, 0f, spawnZ);
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[randomIndex], spawnPos, Quaternion.identity);
    }
}
