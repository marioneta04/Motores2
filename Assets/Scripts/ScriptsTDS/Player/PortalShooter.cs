using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PortalShooter : MonoBehaviour
{
    public GameObject portalPrefab;
    public LayerMask placementMask;
    public float maxDistance = 100f;

    public CrosshairController crosshairController; // Referencia al controlador de la mira

    public Material portalAMaterial;  // Material para portal A (ej: rojo)
    public Material portalBMaterial;  // Material para portal B (ej: violeta)

    private Camera mainCam;
    private GameObject portalA;
    private GameObject portalB;
    private bool placingFirstPortal = true;

    private void Start()
    {
        mainCam = Camera.main;

        // Inicializar color de la mira
        if (crosshairController != null)
        {
            crosshairController.SetToPortalAColor();
        }
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
                if (portalA == null)
                {
                    portalA = Instantiate(portalPrefab, position, rotation);
                    SetPortalMaterial(portalA, portalAMaterial);
                }
                else
                {
                    portalA.transform.position = position;
                    portalA.transform.rotation = rotation;
                    SetPortalMaterial(portalA, portalAMaterial);
                }
            }
            else
            {
                if (portalB == null)
                {
                    portalB = Instantiate(portalPrefab, position, rotation);
                    SetPortalMaterial(portalB, portalBMaterial);
                }
                else
                {
                    portalB.transform.position = position;
                    portalB.transform.rotation = rotation;
                    SetPortalMaterial(portalB, portalBMaterial);
                }
            }

            placingFirstPortal = !placingFirstPortal;

            // Cambiar color de la mira según portal que toca colocar
            if (crosshairController != null)
            {
                if (placingFirstPortal)
                    crosshairController.SetToPortalAColor();
                else
                    crosshairController.SetToPortalBColor();
            }

            if (portalA != null && portalB != null)
            {
                var scriptA = portalA.GetComponent<Portals>();
                var scriptB = portalB.GetComponent<Portals>();

                scriptA.linkedPortal = portalB.transform;
                scriptB.linkedPortal = portalA.transform;
            }
        }
    }

    private void SetPortalMaterial(GameObject portal, Material material)
    {
        var renderer = portal.GetComponentInChildren<Renderer>();
        if (renderer != null && material != null)
        {
            renderer.material = material;
        }
    }
}
