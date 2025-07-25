using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 direction;

    public GameObject impactParticles;
    private bool hasHit = false;

    public float lifetime = 5f; // Tiempo antes de destruir la bala

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    void Start()
    {
        Destroy(gameObject, lifetime); // Destruir después de X segundos
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasHit) return;

        if (other.CompareTag("Player"))
        {
            hasHit = true;

            if (impactParticles != null)
            {
                Instantiate(impactParticles, transform.position, Quaternion.identity);
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Destroy(gameObject);
        }
        else if (!other.CompareTag("Enemy") && !other.isTrigger)
        {
            if (impactParticles != null)
            {
                Instantiate(impactParticles, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
