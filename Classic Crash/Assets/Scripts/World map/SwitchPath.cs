using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPath : MonoBehaviour
{
    public enum Connected { up, down, left, right };
    public List<Connected> MoveOptions;
    public List<BezierCurve> ConnectedPaths;
}