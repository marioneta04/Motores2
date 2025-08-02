using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(1); // Cambia al índice que necesites
        }
    }
}
