using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHits = 2;
    private int currentHits;

    // Si recibe daño de proyectil, muere al instante si esto está activo
    public bool instantDeathFromProjectiles = true;

    void Start()
    {
        currentHits = 0;
    }

    // isProjectile: true si el daño viene de un disparo enemigo
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
        SceneManager.LoadScene(1); // Cambia 1 por el índice de tu escena Game Over si es diferente
    }
}
