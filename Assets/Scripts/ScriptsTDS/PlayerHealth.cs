using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHits = 2;
    private int currentHits;

    // Si recibe da�o de proyectil, muere al instante si esto est� activo
    public bool instantDeathFromProjectiles = true;

    void Start()
    {
        currentHits = 0;
    }

    // isProjectile: true si el da�o viene de un disparo enemigo
    public void TakeDamage(bool isProjectile = false)
    {
        if (instantDeathFromProjectiles && isProjectile)
        {
            Die();
            return;
        }

        currentHits++;
        Debug.Log("Golpe recibido. Hits: " + currentHits);

        if (currentHits >= maxHits)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("El jugador ha muerto.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
