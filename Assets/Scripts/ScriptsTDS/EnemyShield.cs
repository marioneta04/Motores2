using UnityEngine;

public class EnemyShield : MonoBehaviour
{
    public int shieldHealth = 3; // cantidad de impactos que resiste
    public GameObject destroyEffect; // opcional: efecto visual al romperse

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerProjectile"))
        {
            shieldHealth--;

            if (shieldHealth <= 0)
            {
                BreakShield();
            }
        }
    }

    private void BreakShield()
    {
        if (destroyEffect != null)
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
