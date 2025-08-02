using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShootingTDS : MonoBehaviour
{
    public BulletPool bulletPool;  // Referencia al pool de balas
    public Transform firePoint;
    public float bulletSpeed = 20f;

    private PlayerMovementTDS playerController;
    private bool canShoot = false;  // Al principio no puede disparar

    void Awake()
    {
        playerController = GetComponent<PlayerMovementTDS>();
        canShoot = false;  // Lo dejamos sin disparar hasta que agarre el objeto
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.started && canShoot && bulletPool != null)
        {
            Shoot();
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

    // Llamalo cuando el jugador recoja munici�n
    public void EnableShooting(BulletPool pool)
    {
        bulletPool = pool;
        canShoot = true;
    }
}
