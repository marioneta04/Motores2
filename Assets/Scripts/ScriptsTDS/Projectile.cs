using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public float lifetime = 5f;
    public GameObject impactParticles;
    public int damage = 1;

    private float lifeTimer;
    protected bool hasHit = false;

    protected virtual void OnEnable()
    {
        lifeTimer = lifetime;
        hasHit = false;
    }

    protected virtual void Update()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f)
        {
            DeactivateProjectile();
        }
    }

    protected void PlayImpactEffect()
    {
        if (impactParticles != null)
        {
            GameObject particles = Instantiate(impactParticles, transform.position, Quaternion.identity);
            Destroy(particles, 2f);
        }
    }

    protected virtual void DeactivateProjectile()
    {
        gameObject.SetActive(false);
    }

    protected abstract void OnTriggerEnter(Collider other);
}

