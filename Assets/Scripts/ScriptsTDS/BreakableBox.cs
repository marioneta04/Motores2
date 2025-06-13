using UnityEngine;

public class BreakableBox : MonoBehaviour
{
    public int health = 3;
    public GameObject powerUpPrefab;
    public GameObject destroyParticles;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Break();
        }
    }

    void Break()
    {
        if (destroyParticles != null)
        {
            Instantiate(destroyParticles, transform.position, Quaternion.identity);
        }

        if (powerUpPrefab != null)
        {
            Instantiate(powerUpPrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
