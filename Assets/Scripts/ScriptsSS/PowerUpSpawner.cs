using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerUpPrefab;
    public float spawnInterval = 10f;
    public float spawnRangeX = 8f;
    public float spawnZ = 15f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnPowerUp();
            timer = 0f;
        }
    }

    void SpawnPowerUp()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = new Vector3(randomX, 0f, spawnZ);
        Instantiate(powerUpPrefab, spawnPos, Quaternion.identity);
    }
}
