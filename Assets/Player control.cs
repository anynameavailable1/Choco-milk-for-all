using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
//hello nigggas

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);
        if (move > 0) transform.localScale = new Vector3(1, 1, 1);
else if (move < 0) transform.localScale = new Vector3(-1, 1, 1);


        animator.SetFloat("Speed", Mathf.Abs(move));
    }
}
