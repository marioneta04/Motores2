using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyProjectile : Projectile
{
    public float speed = 10f;
    private Vector3 direction;

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        // reset dirección si querés
    }

    protected override void Update()
    {
        base.Update();
        if (!hasHit)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (hasHit) return;

        if (other.CompareTag("Player"))
        {
            hasHit = true;
            PlayImpactEffect();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            DeactivateProjectile();  // Desactiva la bala en vez de destruirla
        }
        else if (!other.CompareTag("Enemy") && !other.isTrigger)
        {
            hasHit = true;
            PlayImpactEffect();
            DeactivateProjectile();
        }
    }
}
