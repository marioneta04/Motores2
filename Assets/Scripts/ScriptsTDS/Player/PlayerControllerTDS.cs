using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTDS : MonoBehaviour
{
    private bool isFree = false;
    public bool IsFree => isFree;

    private HashSet<string> collectedKeys = new HashSet<string>();

    public void SetFree()
    {
        isFree = true;
        Debug.Log("Jugador liberado de la prisión");
    }

    public void CollectKey(string keyID)
    {
        if (!collectedKeys.Contains(keyID))
        {
            collectedKeys.Add(keyID);
            Debug.Log("Llave obtenida: " + keyID);
        }
    }

    public bool HasKey(string keyID)
    {
        return collectedKeys.Contains(keyID);
    }
}
