using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    //Calls the PlayerMovement class.
    public PlayerMovement playerMovement;

    //Sets a respawnpoint in the game.
    public Vector3 respawnPoint;
    // Start is called before the first frame update
    void Start()
    {   
        //Sets based on the transform values.
        respawnPoint = transform.position;
        //If no movement gets the component.
        if (playerMovement == null)
        {
            playerMovement = GetComponent<PlayerMovement>();
        }
    }
    //CheckPoint method used to transform position for respawnPoint.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            respawnPoint = other.transform.position;
        }
    }

    // Update to get the Inputs from the User for movements.
    void Update()
    {
        //Sets values for animations.
        float moveX = Input.GetAxis("Horizontal");
        bool isJumping = Input.GetButton("Jump");
        bool isCrouching = Input.GetKey(KeyCode.C);
        //Move methods 
        playerMovement.Move(moveX, isJumping && playerMovement.isGrounded, isCrouching);
    }
    //Oncollision of character with moving platform sets parent to the platform.
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform") && other.gameObject.activeSelf)
        {
            transform.SetParent(other.transform);
        }
    }
    //If collision ends removes parent and sets to null.
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform") && other.gameObject.activeSelf)
        {
            // Unparent the player when they leave the platform
            transform.SetParent(null);
        }
    }
}