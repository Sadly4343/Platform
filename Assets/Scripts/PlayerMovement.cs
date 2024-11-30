using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    //Movement values for character
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float crouchHeight = 0.5f;
    public float normalHeight = 3f;
    public float crouchSpeed = 2f;
    //Calls animator for animation in game.
    public Animator animator;
    private float moveInput;
    public bool isGrounded = false;


    private Rigidbody2D rb;
    private BoxCollider2D playerCollider;
    private bool isCrouching = false;

    //Sets value of Rigidbody2D and Collider and Freezes rotation for game 2D.
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


        playerCollider = GetComponent<BoxCollider2D>();
        rb.freezeRotation = true;
    }


    void Update()
    {
        //Gets the axis for the Player Movement
        moveInput = Input.GetAxis("Horizontal");

        //Calls method to see if character is in the air or not.
        isGrounded = CheckIfGrounded();
        //Animation values to cause animation based on values.
        animator.SetBool("isWalking", moveInput != 0);
        animator.SetBool("isJumping", !isGrounded);
        //Sets the trigger for jump for animation and if grounded.
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("jumpTrigger");
        }
    }


    //Move method for Player.
    public void Move(float movex, bool isJumping, bool isCrouching)
    {
        //Returns crouch if true
        if (isCrouching && !this.isCrouching)
        {
            Crouch(true);
        }
        //Returns if already crouching and allows them to stand.
        else if (!isCrouching && this.isCrouching)
        {
            Crouch(false);
        }
        //Calculates the movement of character with movex * movespeed and velocity of Y for jumping.
        rb.velocity = new Vector2(movex * moveSpeed, rb.velocity.y);

        //Sets the jumpforce value for velocity if isJumping and IsGrounded variables.
        if (isJumping && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    //Checks if grounded using raycast.
    private bool CheckIfGrounded()
    {
        //Sets the origin point of the raycast to the bottom of the character.
        Vector2 raycastOrigin = new Vector2(transform.position.x, transform.position.y - .7f);
        //Hit value where it will calculate if hit another object.
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, Vector2.down, 0.1f);

        //If collider hits another object return true.
        if (hit.collider != null)
        {
            return true;
        }
        //Else false.
        return false;
    }
    //Crouch method
    private void Crouch(bool crouch)
    {   
        //If crouch is true return 
        if (crouch)
        {
            //Return is true
            isCrouching = true;
            //Change collider size of character.
            playerCollider.size = new Vector2(playerCollider.size.x, crouchHeight);
            //Change movespeed of character.
            moveSpeed = crouchSpeed;
        }
        else
        {
            //Return is false.
            isCrouching = false;
            //Returns normal size values.
            playerCollider.size = new Vector2(playerCollider.size.x, normalHeight);
            //Normal moveSpeed.
            moveSpeed = 5f;
        }
    }
}
