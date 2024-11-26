using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public PlayerMovement playerMovement;


    // Start is called before the first frame update
    void Start()
    {
        if (playerMovement == null)
        {
            playerMovement = GetComponent<PlayerMovement>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        bool isJumping = Input.GetButton("Jump");
        bool isCrouching = Input.GetKey(KeyCode.C);

        playerMovement.Move(moveX, isJumping && playerMovement.isGrounded, isCrouching);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform") && other.gameObject.activeSelf)
        {
            transform.SetParent(other.transform);
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform") && other.gameObject.activeSelf)
        {
            // Unparent the player when they leave the platform
            transform.SetParent(null);
        }
    }
}