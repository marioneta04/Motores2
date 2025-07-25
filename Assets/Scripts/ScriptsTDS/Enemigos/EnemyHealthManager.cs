using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public static EnemyHealthManager Instance;

    public EnemyHealthBar healthBarPrefab;
    public Transform barsParent; // El transform donde van las barras (ejemplo: EnemyHealthBarContainer)

    private List<EnemyHealthBar> availableBars = new List<EnemyHealthBar>();
    private Dictionary<EnemyHealth, EnemyHealthBar> activeBars = new Dictionary<EnemyHealth, EnemyHealthBar>();

    private Camera mainCamera;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        mainCamera = Camera.main;
    }

    void Update()
    {
        // Actualizar posición de las barras activas para que sigan a los enemigos
        foreach (var pair in activeBars)
        {
            EnemyHealth enemy = pair.Key;
            EnemyHealthBar bar = pair.Value;

            if (enemy == null)
            {
                ReturnBarToPool(bar);
                continue;
            }

            Vector3 screenPos = mainCamera.WorldToScreenPoint(enemy.transform.position + Vector3.up * 2f);
            // Ajustá el Vector3.up según qué tan arriba del enemigo querés la barra

            // Si el enemigo está detrás de la cámara, ocultá la barra
            if (screenPos.z < 0)
            {
                bar.gameObject.SetActive(false);
            }
            else
            {
                bar.gameObject.SetActive(true);
                bar.transform.position = screenPos;
            }
        }
    }

    // Asignar una barra a un enemigo, la llama EnemyHealth al iniciar
    public EnemyHealthBar AssignBarToEnemy(EnemyHealth enemy)
    {
        if (activeBars.ContainsKey(enemy))
            return activeBars[enemy];

        EnemyHealthBar bar = GetBarFromPool();
        activeBars.Add(enemy, bar);
        return bar;
    }

    public void RemoveBarFromEnemy(EnemyHealth enemy)
    {
        if (activeBars.TryGetValue(enemy, out EnemyHealthBar bar))
        {
            ReturnBarToPool(bar);
            activeBars.Remove(enemy);
        }
    }

    private EnemyHealthBar GetBarFromPool()
    {
        EnemyHealthBar bar;
        if (availableBars.Count > 0)
        {
            bar = availableBars[0];
            availableBars.RemoveAt(0);
            bar.gameObject.SetActive(true);
        }
        else
        {
            bar = Instantiate(healthBarPrefab, barsParent);
        }
        return bar;
    }

    private void ReturnBarToPool(EnemyHealthBar bar)
    {
        bar.gameObject.SetActive(false);
        availableBars.Add(bar);
    }
}
