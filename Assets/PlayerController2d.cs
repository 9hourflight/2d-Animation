using UnityEngine;

public class PlayerController2d : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Animator animator;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform grounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
            isGrounded = false;
        }

        if (!isGrounded && playerRb.linearVelocityY <= 0.0f)
        {
            animator.SetBool("isFalling", true);
            RaycastHit2D hitInfo = Physics2D.Raycast(grounded.position, Vector2.down, .1f);
            if(hitInfo.collider != null)
            {
                if (hitInfo.transform.CompareTag("ground"))
                {
                    isGrounded = true;
                    animator.SetBool("isJumping", false);
                }
            }
            
        }
    }
}
