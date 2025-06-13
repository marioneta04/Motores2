using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    [Header("Vida")]
    public int maxHealth = 100;
    private int currentHealth;

    [Header("Invocación")]
    public GameObject enemyPrefab;
    public Transform[] summonPoints; // puntos desde donde invoca
    public float summonInterval = 8f;
    private float lastSummonTime;

    [Header("Furia")]
    public bool enraged = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (Time.time - lastSummonTime >= summonInterval)
        {
            SummonEnemies();
            lastSummonTime = Time.time;
        }

        if (!enraged && currentHealth <= maxHealth / 2)
        {
            EnterRageMode();
        }
    }

    void SummonEnemies()
    {
        int summonCount = Mathf.Min(3, summonPoints.Length);

        for (int i = 0; i < summonCount; i++)
        {
            Instantiate(enemyPrefab, summonPoints[i].position, Quaternion.identity);
        }
    }

    void EnterRageMode()
    {
        enraged = true;
        // Si querés podés agregar otros cambios aquí para cuando se enrage.
        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
            rend.material.color = Color.red;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
