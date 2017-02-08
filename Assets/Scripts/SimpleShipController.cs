#define REMOTE
using UnityEngine;


public class SimpleShipController : MonoBehaviour
{
    private Vector2 delta = Vector2.zero;

    private void Awake()
    {

    }

    private void Start()
    {
    }

    private void Update()
    {
#if (UNITY_IOS || UNITY_ANDROID) && !UNITY_EDITOR// || REMOTE
        if (Input.touchCount > 0)
        {
            Touch t = Input.touches[0];
            if (t.phase == TouchPhase.Moved)
            {
                delta.x = t.deltaPosition.x;
                delta.y = t.deltaPosition.y;
            }
        }

#else
        delta.x = Input.GetAxis("Horizontal");
        delta.y = Input.GetAxis("Vertical");
#endif

        transform.Translate(0, delta.y, 0);
        transform.Rotate(0, 0, -delta.x);
    }
}
