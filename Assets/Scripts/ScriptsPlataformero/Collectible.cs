using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int points = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddPoint(points);
            Destroy(gameObject);
        }
    }
}
