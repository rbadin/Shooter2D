using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawn")]
    public GameObject reference;
    [Header("Spawning")]
    [Range(0.001f, 100f)] public float minRate = 1.0f;
    [Range(0.001f, 100f)] public float maxRate = 1.0f;
    public bool infinite;
    public int number = 5;
    [Header("Locations")]
    public GameArea area;

    //private float timeStamp;
    private int remaining;

    private void Start()
    {
        // timeStamp = Time.time;
        remaining = number;
        StartCoroutine("Spawn");
    }

    private IEnumerator Spawn()
    {
        while (infinite || remaining > 0)
        {
            Vector3 position = area ? area.GetRandomPosition() : transform.position;
            //Vector3 position;
            //if (area)
            //    position = area.GetRandomPosition();
            //else
            //    position = transform.position;

            Instantiate(reference, position, transform.rotation);
            remaining--;

            yield return new WaitForSeconds(1 / Random.Range(minRate, maxRate));
        }
    }

    //private void Update()
    //{
    //    if (Time.time <= timeStamp + rate)
    //        return;

    //    timeStamp = Time.time;

    //    if (remaining > 0)
    //    {
    //        Instantiate(reference, transform.position, transform.rotation);
    //        remaining--;

    //        if (remaining <= 0)
    //        {
    //            enabled = false;
    //        }
    //    }
    //}
}
