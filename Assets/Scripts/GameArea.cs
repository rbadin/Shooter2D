using UnityEngine;

/// <summary>
/// Game Area
/// Defines a rectangular area.
/// </summary>
[AddComponentMenu("Badin/Game Area")]
public class GameArea : MonoBehaviour {

    [SerializeField]
    [HideInInspector]
    private Rect area;

    public Rect Area
    {
        get { return area; }
        set { area = value; }
    }

    public Color gizmoColor = new Color(0, 0, 1, 0.2f);
    private Color gizmoWireColor;


    private Vector2 size;
    public Vector2 Size
    {
        get { return Area.size; }
        set
        {
            size = value;
            Area = new Rect(size.x * -0.5f, size.y * -0.5f, size.x, size.y);
        }
    }

    //public void SetArea(Vector2 size)
    //{
       
    //}

    private void OnDrawGizmos()
    {
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = gizmoColor;
        Gizmos.DrawCube(Vector3.zero, new Vector3(Area.width, Area.height,0f));
        Gizmos.color = gizmoWireColor;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(Area.width, Area.height, 0f));

    }
    private void OnValidate()
    {
        Size = size;
        gizmoWireColor = new Color(gizmoColor.r, gizmoColor.g, gizmoColor.b, 1f);
    }

    public Vector3 GetRandomPosition()
    {
        Vector3 randomPos = Vector3.zero;
        randomPos.x = Random.Range(Area.xMin, Area.xMax);
        randomPos.y = Random.Range(Area.yMin, Area.yMax);
        randomPos = transform.TransformPoint(randomPos);
        return randomPos;
    }
}
