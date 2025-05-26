using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;      // jugador
    public Vector3 offset = new Vector3(0, 15, -10);// distancia desde el jugador
    public float smoothSpeed = 5f;


    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;
        transform.rotation = Quaternion.Euler(90f, 0f, 0f); // mirar hacia abajo
    }
}
