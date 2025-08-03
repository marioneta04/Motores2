using UnityEngine;

public class FireRatePowerUp : MonoBehaviour
{
    public float newCooldown = 0f; // 0 significa disparo instantáneo o sin cooldown

    private void OnTriggerEnter(Collider other)
    {
        PlayerShootingTDS shooter = other.GetComponent<PlayerShootingTDS>();
        if (shooter != null)
        {
            shooter.SetCooldown(newCooldown);
            Destroy(gameObject); // Destruye el power-up al ser tomado
        }
    }
}
