using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class loops the object transforms across a rectangle area.
/// When the object leaves the area on the right, it comes back on the left.
/// </summary>
/// 
[AddComponentMenu("Cangaia Corportation/Transform Looper")]
public class TransformLooper : MonoBehaviour
{

    public Rect area;
    Vector3 position;

    private void Update()
    {
        position = transform.position;

        if (area.Contains(position)) return;

        if (position.x < area.xMin)
            position.x = area.xMax;
        else if (position.x > area.xMax)
            position.x = area.xMin;

        if (position.y < area.yMin)
            position.y = area.yMax;
        else if (position.y > area.yMax)
            position.y = area.yMin;

        transform.position = position;
    }
}
