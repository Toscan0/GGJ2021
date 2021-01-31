using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToSpawn;
    private int maxspawn = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxspawn; i++)
        {
            Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
            Instantiate(objectToSpawn, screenPosition, Quaternion.identity);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
