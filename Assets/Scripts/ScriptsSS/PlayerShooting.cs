using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float projectileSpeed = 20f;
    public float fireCooldown = 0.3f; // Tiempo entre disparos

    private float lastFireTime = -Mathf.Infinity;

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            TryShoot();
        }
    }

    void TryShoot()
    {
        if (Time.time >= lastFireTime + fireCooldown)
        {
            Shoot();
            lastFireTime = Time.time;
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = shootPoint.forward * projectileSpeed;
        }
    }
}
