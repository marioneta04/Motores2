using UnityEngine;

public class StartMenuController : MonoBehaviour
{
    public GameObject startMenuPanel;
    public GameObject gameplayUI;
    public CrosshairController crosshair; // <- agregalo en el Inspector

    void Start()
    {
        Time.timeScale = 0f;
        startMenuPanel.SetActive(true);
        if (gameplayUI != null) gameplayUI.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (crosshair != null)
            crosshair.SetActive(false); // <- desactiva la mira
    }

    public void StartGame()
    {
        startMenuPanel.SetActive(false);
        if (gameplayUI != null) gameplayUI.SetActive(true);
        Time.timeScale = 1f;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        if (crosshair != null)
            crosshair.SetActive(true); // <- activa la mira
    }
}
