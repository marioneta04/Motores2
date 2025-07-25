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
                boss.SetActive(true);

            gameObject.SetActive(false); 
        }
    }
}
