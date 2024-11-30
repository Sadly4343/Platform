using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for CameraMovement to follow player as they move through the game.
public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    //Camera Follows player and gets value Transform from Player.
    public Transform Player;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    // Sets the offset value as X,Y,Z and sets up the camera value.
    void Start()
    {
        if (offset == Vector3.zero)
        {
            offset = new Vector3(0, 2, -10);
        }
    }
    //Used to transform the camera with offset, Takes the values of character and moves through transform.
    void LateUpdate()
    {
        Vector3 desiredPosition = Player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
