using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{

    public Image fillImage; // El Image hijo que representa la barra que se llena
    private RectTransform fillRect;

    private float maxWidth;

    void Awake()
    {
        if (fillImage == null)
        {
            Debug.LogError("Fill Image no asignada en EnemyHealthBar");
            return;
        }
        fillRect = fillImage.GetComponent<RectTransform>();
        maxWidth = fillRect.sizeDelta.x;
    }

    // Actualiza la barra con el porcentaje de vida [0..1]
    public void SetHealthPercent(float percent)
    {
        percent = Mathf.Clamp01(percent);
        fillRect.sizeDelta = new Vector2(maxWidth * percent, fillRect.sizeDelta.y);
    }
}
