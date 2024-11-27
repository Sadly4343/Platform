using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float attackRange = 1f;
    public int damage = 10;
    private bool isAttacking = false;


    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
        if (Vector2.Distance(transform.position, player.position) <= attackRange && !isAttacking)
        {
            StartCoroutine(Attack());
        }

    }
    void MoveTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }
    IEnumerator Attack()
    {
        isAttacking = true;
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
        yield return new WaitForSeconds(1f);

        isAttacking = false;

    }
}
