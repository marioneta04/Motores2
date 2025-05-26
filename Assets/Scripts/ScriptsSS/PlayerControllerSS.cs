using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerSS : MonoBehaviour
{
    public float moveSpeed = 10f;
    private float moveX;

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        moveX = input.x;
    }

    void Update()
    {
        Vector3 move = new Vector3(moveX * moveSpeed, 0f, 0f) * Time.deltaTime;
        transform.Translate(move);
    }
}
