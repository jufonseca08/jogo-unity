using UnityEngine;

public class ControlePersonagem : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float moveX;
    private Rigidbody2D rb;

    public Transform groundCheck;
    public LayerMask groudLayer;
    
    private bool isGrounded;

    public Transform visual;
    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        anim= visual.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
       moveX= Input.GetAxisRaw("Horizontal");
       
       isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groudLayer);

       anim.SetBool("IsRunning", Mathf.Abs(moveX) > 0f && isGrounded);
       if (moveX > 0.01f)
       {
        visual.localScale = new Vector3(1, 1, 1);
       }
       else if (moveX < -0.01f)
       {
        visual.localScale = new Vector3(-1, 1, 1);
       }

       if (Input.GetButtonDown("Jump") && isGrounded)
       {
        Jump();
       }
       Move();   
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }
}
