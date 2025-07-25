using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShootingTDS : MonoBehaviour
{
    public BulletPool bulletPool;  // Referencia al pool de balas
    public Transform firePoint;
    public float bulletSpeed = 20f;

    private PlayerMovementTDS playerController;

    void Awake()
    {
        playerController = GetComponent<PlayerMovementTDS>();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 direction = (playerController.lookTarget - firePoint.position).normalized;

        // Tomamos una bala del pool
        GameObject bullet = bulletPool.GetBullet();
        if (bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = Quaternion.LookRotation(direction);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.zero; // Reseteamos velocidad antes de asignar
            rb.AddForce(direction * bulletSpeed, ForceMode.VelocityChange);
        }
    }
}
