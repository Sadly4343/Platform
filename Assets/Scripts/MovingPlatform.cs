using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //Vectors in the game to set for the movement.
    public Vector3 startPoint;
    public Vector3 endPoint;
    public float speed = 2f;

    // Target within the game.
    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        //At start sets the target to the end value.
        target = endPoint;
    }

    // Update is called once per frame
    void Update()
    {
        //MoveTowards takes the distance between the set points and moves the gameobject forward.
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //If the target is less than 0.1f from the game object swaps the target to the other Point and resets.
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = (target == endPoint) ? startPoint : endPoint;
        }
    }
}
