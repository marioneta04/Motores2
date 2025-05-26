using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerControllerSS : MonoBehaviour
{
    public float moveSpeed = 10f;
    private float moveX;

    public float minX = -8f;  // Límite izquierdo
    public float maxX = 8f;   // Límite derecho

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        moveX = input.x;
    }

    void Update()
    {
        Vector3 move = new Vector3(moveX * moveSpeed, 0f, 0f) * Time.deltaTime;
        transform.Translate(move);

        // Clampear posición en X para no salir del área
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("¡El enemigo tocó al jugador!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
