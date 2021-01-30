using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovTest : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * 10 * Time.deltaTime);
    }
}
