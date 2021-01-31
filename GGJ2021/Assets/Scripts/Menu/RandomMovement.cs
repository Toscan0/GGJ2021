using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    private Vector3 newPosition;
    // Start is called before the first frame update
    void Start()
    {
        newPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != newPosition && Vector3.Distance(newPosition, transform.position) > 3)
        {
            var dir = newPosition - transform.position;
            transform.position += dir * Random.Range(0.5f, 1f) * Time.deltaTime;
        }
        else
        {
            newPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
        }
    }
}
