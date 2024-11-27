using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TrapMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public int damage = 69;
    public Vector3 startPoint;
    public Vector3 endPoint;

    private Vector3 target;
    void Start()
    {
        target = endPoint;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = (target == endPoint) ? startPoint : endPoint;
        }
    }
}
