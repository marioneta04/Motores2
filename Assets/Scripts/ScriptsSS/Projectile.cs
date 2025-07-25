using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime = 3f;
    public GameObject impactParticles;
    public int damage = 1;

    private float lifeTimer;

    private void OnEnable()
    {
        lifeTimer = lifetime;
    }

    void Update()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f)
        {
            DeactivateProjectile();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            PlayImpactEffect();
            DeactivateProjectile();
        }
        else if (other.CompareTag("Breakable"))
        {
            BreakableBox box = other.GetComponent<BreakableBox>();
            if (box != null)
            {
                box.TakeDamage(damage);
            }

            PlayImpactEffect();
            DeactivateProjectile();
        }
    }

    void PlayImpactEffect()
    {
        if (impactParticles != null)
        {
            GameObject particles = Instantiate(impactParticles, transform.position, Quaternion.identity);
            Destroy(particles, 2f); // Esto está bien porque es un efecto temporal
        }
    }

    void DeactivateProjectile()
    {
        gameObject.SetActive(false);
    }
}

