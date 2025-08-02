using UnityEngine;

public abstract class MovingBetweenPoints : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 3f;

    protected Vector3 target;

    protected virtual void Start()
    {
        transform.position = pointA.position;
        target = pointB.position;
    }

    protected virtual void Update()
    {
        MoveBetweenPoints();
    }

    protected void MoveBetweenPoints()
    {
        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            target = (target == pointA.position) ? pointB.position : pointA.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
