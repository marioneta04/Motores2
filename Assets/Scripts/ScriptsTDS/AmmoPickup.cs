using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public BulletPool bulletPoolReference; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShootingTDS shooting = other.GetComponent<PlayerShootingTDS>();
            if (shooting != null)
            {
                shooting.EnableShooting(bulletPoolReference);
                Destroy(gameObject); // Desaparece el pickup
            }
        }
    }
}
