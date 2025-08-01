using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBase : MonoBehaviour
{
    protected Transform player;
    protected NavMeshAgent agent;
    protected PlayerControllerTDS playerController;

    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (player == null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
                playerController = player.GetComponent<PlayerControllerTDS>();

                if (playerController == null)
                {
                    Debug.LogWarning("No se encontr� PlayerControllerTDS en el jugador.");
                }
            }
        }
    }

    protected virtual void Update()
    {
        if (player == null || playerController == null || agent == null) return;

        agent.isStopped = !playerController.IsFree;

        if (playerController.IsFree)
        {
            Act();
        }
    }

    protected abstract void Act(); // M�todo para l�gica espec�fica de cada enemig
}
