using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.25f;
    Vector3 vel = Vector3.zero;
    private void FixedUpdate()
    {
        Vector3 destination = target.position + new Vector3(0, 0, -10);
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref vel, smoothTime);
    }
}
