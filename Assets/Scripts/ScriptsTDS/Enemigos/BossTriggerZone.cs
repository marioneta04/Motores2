using Unity.Cinemachine;
using UnityEngine;


public class BossTriggerZone : MonoBehaviour
{
    public GameObject boss;
    public GameObject[] enemiesToActivate; // Array para los enemigos que quieras activar

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;

            if (boss != null)
            {
                boss.SetActive(true);

                BossController bossController = boss.GetComponent<BossController>();
                if (bossController != null)
                    bossController.ActivateBoss();
            }

            // Activar los enemigos junto con el jefe
            if (enemiesToActivate != null)
            {
                foreach (GameObject enemy in enemiesToActivate)
                {
                    if (enemy != null)
                        enemy.SetActive(true);
                }
            }

            gameObject.SetActive(false);
        }
    }
}
