using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime = 3f;
    public GameObject impactParticles;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {

            if (impactParticles != null)
            {
                Instantiate(impactParticles, transform.position, Quaternion.identity);
            }
            Destroy(other.gameObject); // Destruye al enemigo
            Destroy(gameObject);       // Destruye el proyectil
            Destroy(Instantiate(impactParticles, transform.position, Quaternion.identity), 2f);
        }
    }
}

