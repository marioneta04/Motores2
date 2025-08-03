using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerControllerTDS player = other.GetComponent<PlayerControllerTDS>();
        if (player != null)
        {
            SceneManager.LoadScene(2); // Cambia a la escena de victoria
        }
    }
}
