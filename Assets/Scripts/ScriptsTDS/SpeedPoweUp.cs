using UnityEngine;

public class SpeedPoweUp : MonoBehaviour
{
    public float speedIncreaseAmount = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovementTDS playerMovement = other.GetComponent<PlayerMovementTDS>();
            if (playerMovement != null)
            {
                playerMovement.IncreaseSpeed(speedIncreaseAmount);
            }

            Destroy(gameObject); // destruir el power-up una vez recogido
        }
    }
}
