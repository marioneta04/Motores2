using UnityEngine;

public class PrisionExitTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerControllerTDS pc = other.GetComponent<PlayerControllerTDS>();
            if (pc != null && !pc.IsFree)
            {
                pc.SetFree();
            }
        }
    }
}
