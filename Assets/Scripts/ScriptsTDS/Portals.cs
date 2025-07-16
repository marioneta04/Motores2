using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Portals : MonoBehaviour
{
    public Transform linkedPortal;
    public bool preserveDirection = true;

    private HashSet<GameObject> recentlyTeleported = new HashSet<GameObject>();
    private float cooldownTime = 0.2f;

    private void OnTriggerEnter(Collider other)
    {
        if (!recentlyTeleported.Contains(other.gameObject) && other.CompareTag("Player"))
        {
            StartCoroutine(Teleport(other));
        }
    }

    private IEnumerator Teleport(Collider obj)
    {
        // Agrega a la lista para evitar reentrada
        recentlyTeleported.Add(obj.gameObject);
        linkedPortal.GetComponent<Portals>().AddToIgnoreList(obj.gameObject);

        // Teleport con rotación relativa
        CharacterController cc = obj.GetComponent<CharacterController>();
        if (cc) cc.enabled = false;

        Vector3 localOffset = transform.InverseTransformPoint(obj.transform.position);
        Vector3 targetOffset = linkedPortal.TransformPoint(localOffset);

        Quaternion relativeRotation = Quaternion.Inverse(transform.rotation) * obj.transform.rotation;
        Quaternion targetRotation = linkedPortal.rotation * relativeRotation;

        obj.transform.position = targetOffset;
        if (preserveDirection)
            obj.transform.rotation = targetRotation;

        if (cc) cc.enabled = true;

        // Espera un tiempo antes de permitir volver a entrar
        yield return new WaitForSeconds(cooldownTime);

        recentlyTeleported.Remove(obj.gameObject);
    }

    public void AddToIgnoreList(GameObject obj)
    {
        recentlyTeleported.Add(obj);
        StartCoroutine(RemoveFromIgnoreListAfterDelay(obj));
    }

    private IEnumerator RemoveFromIgnoreListAfterDelay(GameObject obj)
    {
        yield return new WaitForSeconds(cooldownTime);
        recentlyTeleported.Remove(obj);
    }
}
