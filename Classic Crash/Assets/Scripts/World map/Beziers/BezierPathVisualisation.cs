using System.Collections;
using UnityEngine;

public class BezierPathVisualisation : MonoBehaviour
{
    public float WaitDisplayNextPathDecoration;
    public int Frequency;
    public Transform[] DecorationItems;
    public bool FirstTime = true;
    private BezierCurve PathToDecorate;
    private World CurrentWorld;

    private void Start()
    {
        CurrentWorld = GetComponentInParent<World>();
        PathToDecorate = GetComponent<BezierCurve>();
        if (PathToDecorate.Unlocked)
        {
            StartCoroutine(DecoratePath());
        }
    }

    private IEnumerator DecoratePath()
    {
        if (Frequency <= 0 || DecorationItems == null || DecorationItems.Length == 0)
        {
            yield return null;
        }
        float StepSize = 1f / (Frequency * DecorationItems.Length);
        for (int p = 0, f = 0; f < Frequency; f++)
        {
            for(int i = 0; i < DecorationItems.Length; i++, p++)
            {
                Transform PathDecorationItem = Instantiate(DecorationItems[i]) as Transform;
                Vector3 Position = PathToDecorate.GetPoint(p * StepSize);
                PathDecorationItem.transform.localPosition = Position;
                PathDecorationItem.transform.LookAt(Position + PathToDecorate.GetDirection(p * StepSize));
                PathDecorationItem.transform.parent = gameObject.transform;
                if (FirstTime)
                {
                    for(int j = 0; j < CurrentWorld.PathDecorationsInWorld.Count; j++)
                    {
                        if(CurrentWorld.PathDecorationsInWorld[j] == this)
                        {
                            GameManager.Instance.WorldMapLocation.DecorationPathsUnlockedFirstTime[j] = false;
                        }
                    }
                    yield return new WaitForSeconds(WaitDisplayNextPathDecoration);
                }
                else
                {
                    yield return null;
                }
            }           
        }
    }
}
