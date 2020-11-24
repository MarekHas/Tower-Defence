using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoint : MonoBehaviour
{
    [SerializeField] private PathPoint[] _points = new PathPoint[0];

    private int nextPointIndex;

    public PathPoint NextPoint
    {
        get
        {
            if (_points.Length == 0) { return null; }

            PathPoint nextPoint = _points[nextPointIndex];

            if (nextPointIndex + 1 != _points.Length)
            {
                nextPointIndex++;
            }
            else
            {
                nextPointIndex = 0;
            }

            return nextPoint;
        }
    }

    #region Debug
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector3 currentPosition = transform.position + new Vector3(0f, 0.5f, 0f);

        Gizmos.DrawWireSphere(currentPosition, 0.5f);

        foreach (var point in _points)
        {
            Gizmos.DrawLine(currentPosition, point.transform.position + new Vector3(0f, 0.5f, 0f));
        }
    }
    #endregion
}
