using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetCamera : MonoBehaviour
{
    public Transform Target;
    public float SmoothSpeed = 0.125f;
    public int Offset;

    private Vector3 StartPosition;
    private Vector3 DesiredPosition;
    private Vector3 SmoothPosition;

    private void OnEnable()
    {
        StartPosition = transform.position;
    }

    private void FixedUpdate()
    {
        DesiredPosition = new Vector3(transform.position.x, transform.position.y, Target.position.z + Offset);
        SmoothPosition = Vector3.Lerp(transform.position, DesiredPosition, SmoothSpeed);
        transform.position = SmoothPosition;
        if (transform.position.z <= StartPosition.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, StartPosition.z);
        }
    }
}
