using UnityEngine;
using UnityEngine.AI;

public class RangedEnemy : EnemyBase
{
    public float stopDistance = 10f;
    public float fireRate = 1.5f;
    public GameObject projectilePrefab;
    public Transform firePoint;

    protected float lastShotTime;

    protected override void Act()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > stopDistance)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        else
        {
            agent.isStopped = true;
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));

            if (Time.time - lastShotTime >= fireRate)
            {
                Shoot();
                lastShotTime = Time.time;
            }
        }
    }

    protected virtual void Shoot()
    {
        if (EnemyProjectilePool.Instance == null)
        {
            Debug.LogWarning("No se encontró una instancia de EnemyProjectilePool.");
            return;
        }

        GameObject projectile = EnemyProjectilePool.Instance.GetProjectile();
        if (projectile != null)
        {
            projectile.transform.position = firePoint.position;
            projectile.transform.rotation = Quaternion.identity;

            Vector3 dirToPlayer = (player.position - firePoint.position).normalized;

            var projScript = projectile.GetComponent<EnemyProjectile>();
            if (projScript != null)
            {
                projScript.SetDirection(dirToPlayer);
            }
        }
    }
}
