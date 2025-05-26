using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemigo destruido: " + other.name);
            Destroy(other.gameObject);
        }
    }
}
