using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShootingTDS : MonoBehaviour
{
    public GameObject bulletPrefab;
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
        // Direcci�n desde el jugador hacia donde mira
        Vector3 direction = (playerController.lookTarget - firePoint.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(direction));
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = direction * bulletSpeed;
    }
}
