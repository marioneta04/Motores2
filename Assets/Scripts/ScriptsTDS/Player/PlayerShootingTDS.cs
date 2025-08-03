using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShootingTDS : MonoBehaviour
{
    public BulletPool bulletPool;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public float fireCooldown = 0.5f; // Tiempo entre disparos

    private PlayerMovementTDS playerController;
    private bool canShoot = false;
    private float lastFireTime = 0f; // Momento del último disparo

    void Awake()
    {
        playerController = GetComponent<PlayerMovementTDS>();
        canShoot = false;
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.started && canShoot && bulletPool != null)
        {
            if (Time.time >= lastFireTime + fireCooldown)
            {
                Shoot();
                lastFireTime = Time.time; // Actualiza el tiempo del último disparo
            }
        }
    }

    void Shoot()
    {
        Vector3 direction = (playerController.lookTarget - firePoint.position).normalized;

        GameObject bullet = bulletPool.GetBullet();
        if (bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = Quaternion.LookRotation(direction);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.zero;
            rb.AddForce(direction * bulletSpeed, ForceMode.VelocityChange);
        }
    }

    public void EnableShooting(BulletPool pool)
    {
        bulletPool = pool;
        canShoot = true;
    }

    public void SetCooldown(float newCooldown)
    {
        fireCooldown = newCooldown;
    }
}
