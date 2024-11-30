using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TrapMovement : MonoBehaviour
{
    // Values for speed and damage of trap. and start and endpoints.
    public float speed = 10f;
    public int damage = 10;
    public Vector3 startPoint;
    public Vector3 endPoint;

    private Vector3 target;
    void Start()
    {
        target = endPoint;
    }
    //Collision method for comparing tag of Player.
    void OnCollisionEnter2D(Collision2D collision)
    {
        //If collides deal damage to the component of Player.
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }


    //Update Method of Trap.
    void Update()
    {
        //Transform position changes towards moving towards the endPoint value.
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //If the distance is less than .1f than change target to the next value and swap them for the update.
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = (target == endPoint) ? startPoint : endPoint;
        }
    }
}
