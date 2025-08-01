using UnityEngine;

public class GameOverCursor : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None; // Libera el cursor
        Cursor.visible = true; // Lo hace visible
    }
}
