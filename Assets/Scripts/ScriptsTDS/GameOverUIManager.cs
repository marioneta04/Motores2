using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIManager : MonoBehaviour
{
    public void RetryGame()
    {
        SceneManager.LoadScene(0); // Carga la escena en el índice 0
    }
}
