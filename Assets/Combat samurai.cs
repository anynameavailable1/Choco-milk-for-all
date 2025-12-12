using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public GameObject attackHitbox;

    void Update()
    {
        // Press J to attack
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger("attack1");
        }
    }

    // Animation Event: enable collider
    public void EnableHitbox()
    {
        attackHitbox.SetActive(true);
    }

    // Animation Event: disable collider
    public void DisableHitbox()
    {
        attackHitbox.SetActive(false);
    }
}
