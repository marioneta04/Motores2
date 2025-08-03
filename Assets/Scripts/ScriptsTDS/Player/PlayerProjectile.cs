using UnityEngine;

public class PlayerProjectile : Projectile
{
    protected override void OnTriggerEnter(Collider other)
    {
        // 1. Bloquear con escudo
        if (other.CompareTag("EnemyShield"))
        {
            PlayImpactEffect();
            DeactivateProjectile();
            return;
        }

        // 2. Dañar enemigo
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
        // 3. Romper cajas
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
        // 4. Paredes
        else if (other.CompareTag("Wall"))
        {
            PlayImpactEffect();
            DeactivateProjectile();
        }
    }
}
