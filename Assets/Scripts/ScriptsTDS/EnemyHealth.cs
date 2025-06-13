using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    private EnemyHealthBar healthBarUI;

    void Start()
    {
        currentHealth = maxHealth;
        healthBarUI = EnemyHealthManager.Instance.AssignBarToEnemy(this);
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthUI()
    {
        if (healthBarUI != null)
        {
            healthBarUI.SetHealthPercent((float)currentHealth / maxHealth);
        }
    }

    private void Die()
    {
        if (healthBarUI != null)
        {
            EnemyHealthManager.Instance.RemoveBarFromEnemy(this);
        }
        Destroy(gameObject);
    }
}
