using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class loops the object transforms across a rectangle area.
/// When the object leaves the area on the right, it comes back on the left.
/// </summary>
/// 
[AddComponentMenu("Badin/Transform Looper")]
public class TransformLooper : MonoBehaviour
{

    public GameArea gameArea;
    Vector3 position;

    private void Update()
    {
        position = gameArea.transform.InverseTransformPoint(transform.position);

        if (gameArea.Area.Contains(position)) return;

        if (position.x < gameArea.Area.xMin)
            position.x = gameArea.Area.xMax;
        else if (position.x > gameArea.Area.xMax)
            position.x = gameArea.Area.xMin;

        if (position.y < gameArea.Area.yMin)
            position.y = gameArea.Area.yMax;
        else if (position.y > gameArea.Area.yMax)
            position.y = gameArea.Area.yMin;

        transform.position = gameArea.transform.InverseTransformPoint(position);
    }

}
