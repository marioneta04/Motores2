using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    public float boostAmount = 10f; 
    public float duration = 5f;     

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController pm = other.GetComponent<PlayerController>();
            if (pm != null)
            {
                if (duration > 0)
                    StartCoroutine(TemporaryJumpBoost(pm));
                else
                    pm.jumpForce += boostAmount;

                Destroy(gameObject); 
            }
        }
    }

    private System.Collections.IEnumerator TemporaryJumpBoost(PlayerController pm)
    {
        pm.jumpForce += boostAmount;
        yield return new WaitForSeconds(duration);
        pm.jumpForce -= boostAmount;
    }
}
