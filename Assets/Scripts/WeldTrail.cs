using System.Collections.Generic;
using UnityEngine;

public class WeldTrail : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform weldTip; // assign tip of the gun
    public LayerMask weldLayer;

    private List<Vector3> weldPoints = new List<Vector3>();
    private bool isWelding = false;

    void Update()
    {
        // Check if welding tip is touching weld surface
        Ray ray = new Ray(weldTip.position, weldTip.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.1f, weldLayer))
        {
            if (!isWelding) isWelding = true;

            Vector3 point = hit.point;

            // Only add if it's far enough from the last point
            if (weldPoints.Count == 0 || Vector3.Distance(weldPoints[weldPoints.Count - 1], point) > 0.01f)
            {
                weldPoints.Add(point);
                lineRenderer.positionCount = weldPoints.Count;
                lineRenderer.SetPositions(weldPoints.ToArray());
            }
        }
        else
        {
            isWelding = false;
        }
    }
}
