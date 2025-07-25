using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CrosshairController : MonoBehaviour
{
    public Image crosshairImage;
    public Color defaultColor = Color.white;
    public Color portalAColor = Color.red;
    public Color portalBColor = Color.magenta;

    public Canvas canvas;
    public Camera mainCamera;

    public bool isActive = true;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        crosshairImage.color = defaultColor;
    }

    private void Update()
    {
        if (!isActive) return;

        Vector2 mousePosition = Mouse.current.position.ReadValue();
        crosshairImage.rectTransform.position = mousePosition;
    }

    public void SetToPortalAColor()
    {
        crosshairImage.color = portalAColor;
    }

    public void SetToPortalBColor()
    {
        crosshairImage.color = portalBColor;
    }

    public void SetToDefaultColor()
    {
        crosshairImage.color = defaultColor;
    }

    public void SetActive(bool value)
    {
        isActive = value;
        crosshairImage.gameObject.SetActive(value);
    }
}
