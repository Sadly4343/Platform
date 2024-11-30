using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Attack and Movespeed Values.
    public float moveSpeed = 1f;
    public float attackRange = 1f;
    public int damage = 10;
    private bool isAttacking = false;

    // Used to get the Transform values of Player and rigidbody attribute for Enemy.
    private Transform player;
    private Rigidbody2D rb;

    // Find gameobject with the tag of Player and GetsComponent and sets rb to this enemy.
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        //Freezes rotation of character in game.
        rb.freezeRotation = true;
    }

    //Calls method of Movetowards Player & Creates StartCouroutine.
    void Update()
    {

        MoveTowardsPlayer();
        //If distance is less than the attackRange and is attacking is false attack.
        if (Vector2.Distance(transform.position, player.position) <= attackRange && !isAttacking)
        {
            //Works to create a routine with delay in the game without pausing.
            StartCoroutine(Attack());
        }

    }
    //Used to retrieve the direction used for the character to move towards the Player and start moving with velocity. Direction*Speed.
    void MoveTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }
    //Used with Coroutine the attack method called when the character is within distance of player.
    IEnumerator Attack()
    {
        //Set to true
        isAttacking = true;
        //Retrieve player health and attack and deal damage.
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
        //Delays next attack 
        yield return new WaitForSeconds(1f);
        //Returns false after attack to reset for update method.
        isAttacking = false;

    }
}
