using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private float attackCooldown = 1f;
    private float lastAttackTime = 0f;

    void OnTriggerStay(Collider other)
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            if (other.CompareTag("Player"))
            {
                PlayerHealth ph = other.GetComponent<PlayerHealth>();
                if (ph != null)
                {
                    ph.TakeDamage();
                    lastAttackTime = Time.time;
                }
            }
        }
    }
}
