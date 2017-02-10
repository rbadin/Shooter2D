using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header ("SPAWN")]
    public GameObject reference;
    [Header("SPAWNING")]
    [Range (0.001f, 100f)] public float rate = 1.0f;
    public bool infinite;
    public int number = 5;

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
        while (infinite|| remaining >0)
        {
            Instantiate(reference, transform.position, transform.rotation);
            remaining--;

            yield return new WaitForSeconds(1 / rate);
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
