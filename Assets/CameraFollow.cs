using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    void Start()
    {
        if (offset == Vector3.zero)
        {
            offset = new Vector3(0, 2, -10);
        }
    }
    void LateUpdate()
    {
        Vector3 desiredPosition = Player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
