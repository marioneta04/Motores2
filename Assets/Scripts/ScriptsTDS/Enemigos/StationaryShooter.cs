using UnityEngine;

public class StationaryShooter :RangedEnemy
{
    protected override void Start()
    {
        base.Start();
        agent.isStopped = true; // No se mueve nunca
    }

    protected override void Act()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= stopDistance)
        {
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));

            if (Time.time - lastShotTime >= fireRate)
            {
                Shoot();
                lastShotTime = Time.time;
            }
        }
    }
}
