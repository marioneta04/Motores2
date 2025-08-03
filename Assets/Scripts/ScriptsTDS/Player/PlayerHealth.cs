using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHits = 2;
    private int currentHits;

    public bool instantDeathFromProjectiles = true;

    private Material playerMaterial;
    private Color originalColor;

    public Color damageColor = new Color(1f, 0f, 0f, 0.7f); // rojo
    public float colorDuration = 1.5f;

    void Start()
    {
        currentHits = 0;

        Renderer renderer = GetComponentInChildren<Renderer>();
        if (renderer != null)
        {
            playerMaterial = renderer.material;
            originalColor = playerMaterial.color;
        }
    }

    public void TakeDamage(bool isProjectile = false)
    {
        if (instantDeathFromProjectiles && isProjectile)
        {
            Die();
            return;
        }

        currentHits++;
        Debug.Log("Golpe recibido. Hits: " + currentHits);

        FlashDamageColor();

        if (currentHits >= maxHits)
        {
            Die();
        }
    }

    private void FlashDamageColor()
    {
        if (playerMaterial == null) return;

        StopAllCoroutines();
        StartCoroutine(FlashColorCoroutine());
    }

    private IEnumerator FlashColorCoroutine()
    {
        playerMaterial.color = damageColor;
        yield return new WaitForSeconds(colorDuration);
        playerMaterial.color = originalColor;
    }

    void Die()
    {
        Debug.Log("El jugador ha muerto.");
        SceneManager.LoadScene(1);
    }

    public void ReceiveHealthPickup()
    {
        if (currentHits == 0)
        {
            maxHits++;
            Debug.Log("Aumenta vida máxima. maxHits: " + maxHits);
        }
        else
        {
            currentHits = Mathf.Max(currentHits - 1, 0);
            Debug.Log("Curación recibida. Hits actuales: " + currentHits);
        }
    }
}
