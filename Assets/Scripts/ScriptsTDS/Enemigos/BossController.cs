using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    [Header("Furia")]
    public bool enraged = false;

    private bool isActive = false;

    // Referencia al shooter (si hay)
    public StationaryShooter shooter;

    public void ActivateBoss()
    {
        isActive = true;
        Debug.Log("Boss activado.");
    }

    public void OnTakeDamage(int currentHealth, int maxHealth)
    {
        if (!isActive)
        {
            Debug.Log("Daño recibido, pero el boss aún no está activo.");
            return;
        }

        if (!enraged && currentHealth <= maxHealth / 2)
        {
            EnterRageMode();
        }
    }

    private void EnterRageMode()
    {
        enraged = true;

        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
            rend.material.color = Color.red;

        if (shooter != null)
        {
            shooter.fireRate *= 0.5f;  // Dispara el doble de rápido
            Debug.Log("Boss en furia: aumentando velocidad de disparo.");
        }
    }

    public void OnBossDeath()
    {
        Debug.Log("Boss muerto. Reiniciando escena.");
       
    }
}
