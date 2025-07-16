using UnityEngine;
using UnityEngine.InputSystem;

public class PortalShooter : MonoBehaviour
{
    public GameObject portalPrefab;
    public LayerMask placementMask;
    public float maxDistance = 100f;

    private Camera mainCam;
    private GameObject portalA;
    private GameObject portalB;
    private bool placingFirstPortal = true;

    private void Start()
    {
        mainCam = Camera.main;
    }

    public void OnShootPortal(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        Ray ray = mainCam.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, placementMask))
        {
            Vector3 position = hit.point;
            Quaternion rotation = Quaternion.LookRotation(hit.normal);

            if (placingFirstPortal)
            {
                // Crear o mover Portal A
                if (portalA == null)
                {
                    portalA = Instantiate(portalPrefab, position, rotation);
                }
                else
                {
                    portalA.transform.position = position;
                    portalA.transform.rotation = rotation;
                }
            }
            else
            {
                // Crear o mover Portal B
                if (portalB == null)
                {
                    portalB = Instantiate(portalPrefab, position, rotation);
                }
                else
                {
                    portalB.transform.position = position;
                    portalB.transform.rotation = rotation;
                }
            }

            placingFirstPortal = !placingFirstPortal;

            // Si ambos existen, conectarlos
            if (portalA != null && portalB != null)
            {
                var scriptA = portalA.GetComponent<Portals>();
                var scriptB = portalB.GetComponent<Portals>();

                scriptA.linkedPortal = portalB.transform;
                scriptB.linkedPortal = portalA.transform;
            }
        }
    }
}
