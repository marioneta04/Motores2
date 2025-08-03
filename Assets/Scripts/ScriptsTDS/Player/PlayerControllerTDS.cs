using UnityEngine;

public class PlayerControllerTDS : MonoBehaviour
{
    public bool hasKey = false;
    private bool isFree = false;

    public bool IsFree => isFree;

    public void SetFree()
    {
        isFree = true;
        Debug.Log("Jugador liberado de la prisión");
    }

    public void CollectKey()
    {
        hasKey = true;
    }
}
