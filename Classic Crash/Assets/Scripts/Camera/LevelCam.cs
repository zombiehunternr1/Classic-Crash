using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCam : MonoBehaviour
{
    public Transform Player;
    public Vector3 Offset;
    public float SmoothPositioning = .5f;

    public float MinZoom = 40f;
    public float MaxZoom = 10f;
    public float ZoomLimiter = 50f;
    public float SmoothZoom = 5f;

    public static bool AllowY = true;
    public static bool AllowZ = true;
    private float YLock;
    private float ZLock;
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
        CheckAllowedCameraMovement(NewPosition);
        UpdateCameraPosition(NewPosition);
    }

    private void CheckAllowedCameraMovement(Vector3 NewPosition)
    {
        if (AllowY && AllowZ)
        {
            transform.position = Vector3.SmoothDamp(transform.position, NewPosition, ref Velocity, SmoothPositioning);
        }
        else if (AllowY && !AllowZ)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(NewPosition.x, NewPosition.y, ZLock), ref Velocity, SmoothPositioning);
        }
        else if (!AllowY && AllowZ)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(NewPosition.x, YLock, NewPosition.z), ref Velocity, SmoothPositioning);
        }
    }

    private void UpdateCameraPosition(Vector3 NewPosition)
    {
        if (AllowY)
        {
            YLock = transform.position.y;
        }
        if (AllowZ)
        {
            ZLock = transform.position.z;
        }
        else
        {
            if (YLock != LastPosition.y)
            {
                SetupCam();
            }
            if (ZLock != LastPosition.z)
            {
                SetupCam();
            }
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(NewPosition.x, YLock, ZLock), ref Velocity, SmoothPositioning);
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
        Vector3 CenterPoint = GetCenterPoint();
        Vector3 NewPosition = CenterPoint + Offset;
        if (AllowY)
        {
            YLock = NewPosition.y;
        }
        if (AllowZ)
        {
            ZLock = NewPosition.z;
        }
        else if(!AllowY)
        {
            YLock = Mathf.Round(YLock);
        }
        else if (!AllowZ)
        {
            ZLock = Mathf.Round(ZLock);

        }
    }

    private Vector3 GetCenterPoint()
    {
        Bounds Boundary = new Bounds(Player.position, Vector3.zero);
        Boundary.Encapsulate(Player.position);
        return Boundary.center;
    }
}
