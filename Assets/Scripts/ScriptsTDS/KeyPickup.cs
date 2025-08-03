using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerControllerTDS player = other.GetComponent<PlayerControllerTDS>();
        if (player != null)
        {
            player.CollectKey();
            Destroy(gameObject);
        }
    }
}
