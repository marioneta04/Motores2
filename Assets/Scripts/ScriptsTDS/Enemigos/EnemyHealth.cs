using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5;
    protected int currentHealth; // <-- antes era privado

    protected EnemyHealthBar healthBarUI;

    protected virtual void Start() // <-- cambiamos a protected virtual
    {
        currentHealth = maxHealth;
        healthBarUI = EnemyHealthManager.Instance.AssignBarToEnemy(this);
        UpdateHealthUI();
    }

    public virtual void TakeDamage(int damage) // <-- también virtual
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected void UpdateHealthUI()
    {
        if (healthBarUI != null)
        {
            healthBarUI.SetHealthPercent((float)currentHealth / maxHealth);
        }
    }

    protected virtual void Die()
    {
        if (healthBarUI != null)
        {
            EnemyHealthManager.Instance.RemoveBarFromEnemy(this);
        }
        Destroy(gameObject);
    }
}
