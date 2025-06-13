using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime = 3f;
    public GameObject impactParticles;
    public int damage = 1; // Cantidad de daño que hace la bala

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Intentar obtener el componente EnemyHealth
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            if (impactParticles != null)
            {
                GameObject particles = Instantiate(impactParticles, transform.position, Quaternion.identity);
                Destroy(particles, 2f);
            }

            Destroy(gameObject); // Destruir la bala (no el enemigo)
        }
    }
}

