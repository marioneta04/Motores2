using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoorSlide : MonoBehaviour
{
    public Transform doorModel; // Referencia al objeto que se mueve
    public Vector3 slideOffset = new Vector3(3f, 0f, 0f);
    public float slideDuration = 1f;

    public Text messageText; // Asignar en inspector: texto UI para mensajes
    public float messageDuration = 2f;

    public string requiredKeyID; // ID de la llave necesaria para abrir

    private bool isOpening = false;
    private Collider blockingCollider;

    private void Awake()
    {
        if (doorModel == null)
            doorModel = transform.Find("DoorModel");

        blockingCollider = doorModel.GetComponent<Collider>();

        if (messageText != null)
            messageText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerControllerTDS player = other.GetComponent<PlayerControllerTDS>();
        if (player != null)
        {
            if (player.HasKey(requiredKeyID) && !isOpening)
            {
                StartCoroutine(SlideDoor());
                isOpening = true;
            }
            else if (!player.HasKey(requiredKeyID))
            {
                ShowMessage("Primero debes tener la llave");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerControllerTDS player = other.GetComponent<PlayerControllerTDS>();
        if (player != null && messageText != null)
        {
            HideMessage();
        }
    }

    private IEnumerator SlideDoor()
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

    private void ShowMessage(string message)
    {
        if (messageText != null)
        {
            messageText.text = message;
            messageText.gameObject.SetActive(true);
            CancelInvoke(nameof(HideMessage));
            Invoke(nameof(HideMessage), messageDuration);
        }
    }

    private void HideMessage()
    {
        if (messageText != null)
        {
            messageText.gameObject.SetActive(false);
        }
    }
}
