using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetCamera : MonoBehaviour
{
    public Transform Target;
    public float SmoothSpeed = 0.125f;
    public float SmoothRotation = 1f;
    public int Offset;

    private Camera Camera;
    private Vector3 ViewPos;
    private bool InViewPort;

    private Vector3 StartPosition;
    private Vector3 DesiredPosition;
    private Vector3 SmoothPosition;

    private void OnEnable()
    {
        StartPosition = transform.position;
        Camera = GetComponent<Camera>();
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

        if(transform.position.z > Target.position.z - Offset)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.position, SmoothSpeed * Time.fixedDeltaTime);
        }

        ViewPos = Camera.WorldToViewportPoint(Target.position);
        InViewPort = ViewPos.x >= 0.2 && ViewPos.x <= 0.8 && ViewPos.y >= 0 && ViewPos.y <= 1 && ViewPos.z > 0;

        if (!InViewPort)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Target.position - transform.position), SmoothRotation * Time.fixedDeltaTime);
        }
    }
}
