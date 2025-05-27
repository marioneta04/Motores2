using UnityEngine;

public class PowerUpRapidFire : MonoBehaviour
{
    public float powerUpDuration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        PlayerShooting shooting = other.GetComponent<PlayerShooting>();
        if (shooting != null)
        {
            shooting.SetTemporaryCooldown(0f, powerUpDuration);
            Destroy(gameObject); // Elimina el power-up al activarse
        }
    }
}
