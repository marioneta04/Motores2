using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    [Header("Vida")]
    public int maxHealth = 100;
    private int currentHealth;

    [Header("Invocación")]
    public GameObject[] enemyPrefabs;
    public Transform[] summonPoints;
    public float summonInterval = 8f;
    private float lastSummonTime;

    [Header("Furia")]
    public bool enraged = false;

    private bool isActive = false;

    void Start()
    {
        currentHealth = maxHealth;
        isActive = false; // No empieza activo
    }

    void Update()
    {
        if (!isActive)
        {
            Debug.Log(" Boss aún no activo");
            return;
        }

        Debug.Log(" Boss activo, corriendo Update");

        if (Time.time - lastSummonTime >= summonInterval)
        {
            Debug.Log(" Intentando invocar enemigos...");
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
        Debug.Log(" Invocando enemigos");
        int summonCount = Mathf.Min(3, summonPoints.Length);

        for (int i = 0; i < summonCount; i++)
        {
            GameObject prefabToSummon = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Instantiate(prefabToSummon, summonPoints[i].position, Quaternion.identity);
        }
    }

    void EnterRageMode()
    {
        enraged = true;
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

    public void ActivateBoss()
    {
        isActive = true;
        lastSummonTime = Time.time; // Inicializa el temporizador de invocación aquí
        Debug.Log("ActivateBoss llamado correctamente, el temporizador de invocación ha sido inicializado.");
    }
}
