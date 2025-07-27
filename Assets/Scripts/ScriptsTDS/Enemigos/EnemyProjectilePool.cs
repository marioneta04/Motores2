using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectilePool : MonoBehaviour
{
    public static EnemyProjectilePool Instance { get; private set; }

    public GameObject enemyProjectilePrefab;
    public int poolSize = 20;

    private List<GameObject> pool;

    private void Awake()
    {
        // Configurar Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        // Inicializar el pool
        pool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject proj = Instantiate(enemyProjectilePrefab);
            proj.SetActive(false);
            pool.Add(proj);
        }
    }

    public GameObject GetProjectile()
    {
        foreach (GameObject proj in pool)
        {
            if (!proj.activeInHierarchy)
            {
                proj.SetActive(true);
                return proj;
            }
        }

        // Si no hay disponibles, instanciar uno nuevo (puede ser opcional)
        GameObject newProj = Instantiate(enemyProjectilePrefab);
        newProj.SetActive(true);
        pool.Add(newProj);
        return newProj;
    }
}
