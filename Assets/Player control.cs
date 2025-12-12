using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

//hello 
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    private bool isGrounded;

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);
        if (move > 0) transform.localScale = new Vector3(1, 1, 1);
else if (move < 0) transform.localScale = new Vector3(-1, 1, 1);


        animator.SetFloat("Speed", Mathf.Abs(move));

isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, whatIsGround);

        // 3️⃣ Jump input + animation
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetBool("isJumping", true);
        }

        // 4️⃣ Reset jump animation when on ground
        if (isGrounded && rb.linearVelocity.y <= 0)
        {
            animator.SetBool("isJumping", false);
        }





    }
    






}
