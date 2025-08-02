using UnityEngine;

public class PlayerProjectile : Projectile
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            PlayImpactEffect();
            DeactivateProjectile();
        }
        else if (other.CompareTag("Breakable"))
        {
            var box = other.GetComponent<BreakableBox>();
            if (box != null)
            {
                box.TakeDamage(damage);
            }

            PlayImpactEffect();
            DeactivateProjectile();
        }
        else if (other.CompareTag("Wall"))
        {
            PlayImpactEffect();
            DeactivateProjectile();
        }
    }
}
