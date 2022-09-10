using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform location;
    public float moveSpeed;

    void FixedUpdate()
    {
        Vector3 spot = new Vector3(location.transform.position.x, location.transform.position.y, -10);
        transform.position = Vector3.Lerp (transform.position, spot, moveSpeed);
    }
}
