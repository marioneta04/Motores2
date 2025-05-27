using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float projectileSpeed = 20f;
    public float fireCooldown = 0.3f; // Cooldown base
    private float currentCooldown;

    private float lastFireTime = -Mathf.Infinity;

    void Start()
    {
        currentCooldown = fireCooldown;
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            TryShoot();
        }
    }

    void TryShoot()
    {
        if (Time.time >= lastFireTime + currentCooldown)
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

    public void SetTemporaryCooldown(float newCooldown, float duration)
    {
        StopAllCoroutines();
        StartCoroutine(TemporaryCooldownCoroutine(newCooldown, duration));
    }

    private IEnumerator TemporaryCooldownCoroutine(float newCooldown, float duration)
    {
        currentCooldown = newCooldown;
        yield return new WaitForSeconds(duration);
        currentCooldown = fireCooldown;
    }
}
