using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform Player;
    public Vector3 Offset;
    public float SmoothPositioning = .5f;

    public float MinZoom = 40f;
    public float MaxZoom = 10f;
    public float ZoomLimiter = 50f;
    public float SmoothZoom = 5f;

    public static bool AllowY = true;
    public float YLock;
    private Vector3 Velocity;
    private Vector3 LastPosition;
    private Camera Cam;

    private void Start()
    {
        Cam = GetComponent<Camera>();
        SetupCam();
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
        Vector3 CenterPoint = GetCenterPoint();
        Vector3 NewPosition = CenterPoint + Offset;
        LastPosition = NewPosition;
        if (AllowY)
        {
            transform.position = Vector3.SmoothDamp(transform.position, NewPosition, ref Velocity, SmoothPositioning);
            YLock = transform.position.y;

        }
        else
        {
            if(YLock != LastPosition.y)
            {
                SetupCam();
            }
            else
            {
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(NewPosition.x, YLock, NewPosition.z), ref Velocity, SmoothPositioning);
            }
        }
    }

    private void Zoom()
    {
        if(transform.position == LastPosition)
        {
            Cam.fieldOfView = Mathf.Lerp(Cam.fieldOfView, MaxZoom, SmoothZoom * Time.deltaTime);
        }
        else
        {
            Cam.fieldOfView = Mathf.Lerp(Cam.fieldOfView, MinZoom, SmoothZoom * Time.deltaTime);
        }
    }

    private void SetupCam()
    {
        if (AllowY)
        {
            Vector3 CenterPoint = GetCenterPoint();
            Vector3 Newposition = CenterPoint + Offset;
            YLock = Newposition.y;
        }
        else
        {
            Vector3 CenterPoint = GetCenterPoint();
            Vector3 NewPosition = CenterPoint + Offset;
            YLock = Mathf.Round(YLock);
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(NewPosition.x, YLock, NewPosition.z), ref Velocity, SmoothPositioning);
        }
    }

    private Vector3 GetCenterPoint()
    {
        Bounds Boundary = new Bounds(Player.position, Vector3.zero);
        Boundary.Encapsulate(Player.position);
        return Boundary.center;
    }
}
