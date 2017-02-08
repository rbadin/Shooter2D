using UnityEngine;

public class SimpleShipController : MonoBehaviour
{

    private void Awake()
    {

    }

    private void Start()
    {
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.Translate(0, y, 0);
        transform.Rotate(0, 0, -x);
    }
}
