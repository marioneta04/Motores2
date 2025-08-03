using UnityEngine;

public class BossHealth : EnemyHealth
{
    private BossController bossController;

    [Header("Key Drop Settings")]
    public GameObject keyPrefab;      // Prefab de la llave
    public string keyID = "prisonDoor"; // ID de la llave que abrir� la puerta
    public Transform dropPoint;       // Punto donde aparecer� la llave (opcional)

    protected override void Start()
    {
        base.Start();
        bossController = GetComponent<BossController>();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        if (bossController != null)
        {
            bossController.OnTakeDamage(currentHealth, maxHealth);
        }
    }

    protected override void Die()
    {
        DropKey();

        if (bossController != null)
        {
            bossController.OnBossDeath(); // delegamos la muerte al controlador
        }

        base.Die(); // puede incluir la destrucci�n o no, seg�n c�mo manejes la escena
    }

    private void DropKey()
    {
        if (keyPrefab != null)
        {
            GameObject key = Instantiate(
                keyPrefab,
                dropPoint != null ? dropPoint.position : transform.position,
                Quaternion.identity
            );

            KeyPickup keyPickup = key.GetComponent<KeyPickup>();
            if (keyPickup != null)
            {
                keyPickup.keyID = keyID;
            }
        }
    }
}
