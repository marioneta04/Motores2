using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
