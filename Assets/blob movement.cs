using UnityEngine;

public class blob : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Full 2D movement
        rb.linearVelocity = new Vector2(moveX * speed, moveY * speed);

        // Flip sprite horizontally
        if (moveX > 0) 
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveX < 0) 
            transform.localScale = new Vector3(-1, 1, 1);

        // Animation speed parameter works same as Samurai
        animator.SetFloat("Speed", Mathf.Abs(moveX) + Mathf.Abs(moveY));
    }
}
