using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovemnt : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 5f;

    private Vector3 target;
    void Start()
    {
        target = pointA.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = target == pointA.position ? pointB.position : pointA.position;
        }

    }
}
