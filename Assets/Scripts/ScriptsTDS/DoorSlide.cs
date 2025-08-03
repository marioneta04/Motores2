using UnityEngine;

public class DoorSlide : MonoBehaviour
{
    public Transform doorModel; // Referencia al objeto que se mueve
    public Vector3 slideOffset = new Vector3(3f, 0f, 0f);
    public float slideDuration = 1f;

    private bool isOpening = false;
    private Collider blockingCollider;

    private void Awake()
    {
        if (doorModel == null)
            doorModel = transform.Find("DoorModel");

        blockingCollider = doorModel.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerControllerTDS player = other.GetComponent<PlayerControllerTDS>();
        if (player != null && player.hasKey && !isOpening)
        {
            StartCoroutine(SlideDoor());
            isOpening = true;
        }
    }

    private System.Collections.IEnumerator SlideDoor()
    {
        Vector3 startPos = doorModel.position;
        Vector3 endPos = startPos + slideOffset;

        float elapsed = 0f;

        while (elapsed < slideDuration)
        {
            doorModel.position = Vector3.Lerp(startPos, endPos, elapsed / slideDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        doorModel.position = endPos;

        if (blockingCollider != null)
            blockingCollider.enabled = false;
    }
}
