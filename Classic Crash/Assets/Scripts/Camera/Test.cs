using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform Player;
    public Vector3 Offset;
    public float SmoothTime = .5f;

    public float MinZoom = 40f;
    public float MaxZoom = 10f;
    public float ZoomLimiter = 50f;

    private Vector3 Velocity;
    private Vector3 LastPosition;
    private Camera Cam;

    private void Start()
    {
        Cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if(Player == null)
        {
            return;
        }
        Move();
        Zoom();
    }

    private void Move()
    {
        LastPosition = transform.position;
        Vector3 CenterPoint = GetCenterPoint();
        Vector3 NewPosition = CenterPoint + Offset;
        transform.position = Vector3.SmoothDamp(transform.position, NewPosition, ref Velocity, SmoothTime);
    }

    private void Zoom()
    {
        if(transform.position == LastPosition)
        {
            Cam.fieldOfView = Mathf.Lerp(Cam.fieldOfView, MaxZoom, MinZoom * Time.deltaTime);
        }
        else
        {
            Cam.fieldOfView = Mathf.Lerp(Cam.fieldOfView, MinZoom, MaxZoom * Time.deltaTime);
        }
    }

    private Vector3 GetCenterPoint()
    {
        Bounds Boundary = new Bounds(Player.position, Vector3.zero);
        Boundary.Encapsulate(Player.position);
        return Boundary.center;
    }
}
