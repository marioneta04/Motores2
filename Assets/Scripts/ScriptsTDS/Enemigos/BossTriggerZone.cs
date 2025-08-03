using Unity.Cinemachine;
using UnityEngine;


public class BossTriggerZone : MonoBehaviour
{
    public GameObject boss;

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

                // Activar comportamiento del boss
                BossController bossController = boss.GetComponent<BossController>();
                if (bossController != null)
                    bossController.ActivateBoss();
            }

            gameObject.SetActive(false);
        }
    }
}
