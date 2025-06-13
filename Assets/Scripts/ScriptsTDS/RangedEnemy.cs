using UnityEngine;
using UnityEngine.AI;

public class RangedEnemy : MonoBehaviour
{
    public Transform player;
    public float stopDistance = 10f;
    public float fireRate = 1.5f;
    public GameObject projectilePrefab;
    public Transform firePoint;

    private NavMeshAgent agent;
    private float lastShotTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (player == null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
            else
            {
                Debug.LogWarning("No se encontró un objeto con tag 'Player'");
            }
        }
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > stopDistance)
        {
            // Acercarse al jugador
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        else
        {
            // Parar y disparar
            agent.isStopped = true;
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z)); 

            if (Time.time - lastShotTime >= fireRate)
            {
                Shoot();
                lastShotTime = Time.time;
            }
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        Vector3 dirToPlayer = (player.position - firePoint.position).normalized;

        EnemyProjectile projScript = projectile.GetComponent<EnemyProjectile>();
        if (projScript != null)
        {
            projScript.SetDirection(dirToPlayer);
        }
    }
}
