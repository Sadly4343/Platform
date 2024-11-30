using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float crouchHeight = 0.5f;
    public float normalHeight = 3f;
    public float crouchSpeed = 2f;
    public Animator animator;
    private float moveInput;
    public bool isGrounded = false;


    private Rigidbody2D rb;
    private BoxCollider2D playerCollider;
    private bool isCrouching = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


        playerCollider = GetComponent<BoxCollider2D>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        isGrounded = CheckIfGrounded();

        animator.SetBool("isWalking", moveInput != 0);
        animator.SetBool("isJumping", !isGrounded);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("jumpTrigger");
        }
    }


    public void Move(float movex, bool isJumping, bool isCrouching)
    {
        if (isCrouching && !this.isCrouching)
        {
            Crouch(true);
        }
        else if (!isCrouching && this.isCrouching)
        {
            Crouch(true);
        }
        rb.velocity = new Vector2(movex * moveSpeed, rb.velocity.y);

        if (isJumping && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    private bool CheckIfGrounded()
    {
        Vector2 raycastOrigin = new Vector2(transform.position.x, transform.position.y - .7f);

        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, Vector2.down, 0.1f);


        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
    private void Crouch(bool crouch)
    {
        if (crouch)
        {
            isCrouching = true;
            playerCollider.size = new Vector2(playerCollider.size.x, crouchHeight);
            moveSpeed = crouchSpeed;
        }
        else
        {
            isCrouching = false;
            playerCollider.size = new Vector2(playerCollider.size.x, normalHeight);
            moveSpeed = 5f;
        }
    }
}
